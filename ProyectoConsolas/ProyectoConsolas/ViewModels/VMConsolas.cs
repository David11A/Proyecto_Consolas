using System;
using ProyectoConsolas.Models;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace ProyectoConsolas.ViewModels
{
    public class VMConsolas : INotifyPropertyChanged
    {
        public VMConsolas()
        {
            ToggleListaJuegosCommand = new Command(ToggleJuegos);
            ToggleEditarCommand = new Command(ToggleEditar);
            FechaLanzamiento = DateTime.Today;
            ToggleModalCommand = new Command(ToggleModal);
            GetConsolas();
            RegistrarConsolaCommand = new Command(async () => await RegistrarConsolaAsync());
            ActualizarConsolaCommand = new Command(async () => await ActualizarConsolaAsync());
            EliminarConsolaCommand = new Command<string>(async (id) => await EliminarConsolaAsync(id));
            EditarConsolaCommand = new Command<ItemConsolas>(EditarConsola);
            JuegosConsolaCommand = new Command<ItemConsolas>(async (consola) => await GetJuegosConsolas(consola.consolaid));
        }


        private DateTime _fechaLanzamiento;
        public DateTime FechaLanzamiento
        {
            get => _fechaLanzamiento;
            set
            {
                if (_fechaLanzamiento != value)
                {
                    _fechaLanzamiento = value;
                    OnPropertyChanged(nameof(FechaLanzamiento));
                }
            }
        }

        public ICommand RegistrarConsolaCommand { get; private set; }
        public ICommand ActualizarConsolaCommand { get; private set; }
        public ICommand EditarConsolaCommand { get; private set; }
        public ICommand JuegosConsolaCommand { get; private set; }

        public ICommand EliminarConsolaCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;


        private bool _listVisible = true;
        private bool _isModalVisible = false;
        private bool _modalEditar = false;
        private bool _listaJuegos = false;

        public bool IsModalVisible
        {
            get { return _isModalVisible; }
            set
            {
                _isModalVisible = value;
                OnPropertyChanged(nameof(IsModalVisible)); 
            }
        }

        public bool ModalEditar
        {
            get { return _modalEditar; }
            set
            {
                _modalEditar = value;
                OnPropertyChanged(nameof(ModalEditar));
            }
        }

        public bool listVisible {
            get { return _listVisible; }
            set
            {
                _listVisible = value;
                OnPropertyChanged(nameof(listVisible));
            }
        }

        public bool listaJuegos
        {
            get { return _listaJuegos; }
            set
            {
                _listaJuegos = value;
                OnPropertyChanged(nameof(listaJuegos));
            }
        }


        public ICommand ToggleModalCommand { get; private set; }
        public ICommand ToggleEditarCommand { get; private set; }
        public ICommand ToggleListaJuegosCommand {  get; private set; }

        private RegistroConsolas _consolaEditada;
        public RegistroConsolas ConsolaEditada
        {
            get => _consolaEditada;
            set
            {
                _consolaEditada = value;
                OnPropertyChanged(nameof(ConsolaEditada));
            }
        }



        private async void GetConsolas()
        {
            string url = "https://apex.oracle.com/pls/apex/juegos/api/examen/consolas";

            ConsumoServicios servicios = new ConsumoServicios(url);
            ListaConsolas.Clear();

            var response = await servicios.Get<ConsolasResponse>();
            foreach (ItemConsolas x in response.items)
            {
                ItemConsolas temp = new ItemConsolas()
                {
                    consolaid = x.consolaid,
                    nombre = x.nombre,
                    fabricante = x.fabricante,
                    fechalanzamiento = x.fechalanzamiento,
                    enlaceimagen = x.enlaceimagen
                };

                ListaConsolas.Add(temp);
            }
        }

       private async Task GetJuegosConsolas(int? consolaidFiltro)
        {
            string url = "https://apex.oracle.com/pls/apex/juegos/api/examen/consolas/videojuegos";

            ConsumoServicios servicios = new ConsumoServicios(url);
            ListaJuegosConsolas.Clear();

            var response = await servicios.Get<Response_juego_consola>();

            // Filtrar por consolaid si consolaidFiltro no es null y es diferente de 0
            var juegosFiltrados = consolaidFiltro.HasValue && consolaidFiltro.Value != 0
                ? response.items.Where(x => x.consolaid == consolaidFiltro.Value)
                : response.items;

            foreach (Item_juego_consola x in juegosFiltrados)
            {
                Item_juego_consola temp = new Item_juego_consola()
                {
                    cv_id = x.cv_id,
                    consolaid = x.consolaid,
                    videojuegoid = x.videojuegoid,
                    titulo_consola = x.titulo_consola,
                    titulo_videojuego = x.titulo_videojuego
                };
                ListaJuegosConsolas.Add(temp);
            }
            listaJuegos=true;
            listVisible = false;
        }


        private async Task RegistrarConsolaAsync()
        {
            string url = "https://apex.oracle.com/pls/apex/juegos/api/examen/consolas";
            ConsumoServicios servicios = new ConsumoServicios(url);

            RegistroConsolas nuevaConsola = new RegistroConsolas
            {
                nombre = Nombre,
                fabricante = Fabricante,
                fechalanzamiento = FechaLanzamiento.ToString("yyyy-MM-dd"),
                enlaceimagen = EnlaceImagen
            };

            try
            {
                var response = await servicios.PostAsync<RegistroConsolas>(nuevaConsola);
                await Application.Current.MainPage.DisplayAlert("Éxito", "La consola se ha registrado exitosamente.", "Ok");
                GetConsolas();
                IsModalVisible = false; 
                listVisible = true;
            }
            catch (Exception ex)
            {
                // En caso de error, mostramos un alert.
                await Application.Current.MainPage.DisplayAlert("Error", "Error al registrar la consola: " + ex.Message, "Ok");
            }
        }


        private void EditarConsola(ItemConsolas consola)
        {
            ConsolaEditada = new RegistroConsolas
            {
                consolaid = consola.consolaid,
                nombre = consola.nombre,
                fabricante = consola.fabricante,
                fechalanzamiento = consola.fechalanzamiento,
                enlaceimagen = consola.enlaceimagen,
            };
            FechaLanzamiento = DateTime.Parse(consola.fechalanzamiento);
            ToggleEditar();
        }

        private void JuegoConsola(ItemConsolas consola)
        {
            ConsolaId = consola.consolaid;

            ToggleEditar();
        }

        private async Task ActualizarConsolaAsync()
        {
            int id = ConsolaEditada.consolaid;
            string url = $"https://apex.oracle.com/pls/apex/juegos/api/examen/consolas?consolaid={id}"; 
            ConsumoServicios servicios = new ConsumoServicios(url);
            RegistroConsolas consolaActualizada = new RegistroConsolas
            {
                nombre = Nombre,
                fabricante = Fabricante,
                fechalanzamiento = FechaLanzamiento.ToString("yyyy-MM-dd"),
                enlaceimagen = EnlaceImagen
            };

            try
            {
                var response = await servicios.PutAsync<RegistroConsolas>(consolaActualizada);
            }
            catch (Exception ex)
            {
                // Manejar error
            }
        }

        private async Task EliminarConsolaAsync(string id)
        {
            string url = $"https://apex.oracle.com/pls/apex/juegos/api/examen/consolas?consolaid={id}"; // Asume esta URL para el endpoint de eliminación
            ConsumoServicios servicios = new ConsumoServicios(url);

            try
            {
                var response = await servicios.DeleteAsync<RegistroConsolas>();
            }
            catch (Exception ex)
            {
                // Manejar error
            }
        }


        private void ToggleModal()
        {
            IsModalVisible = !IsModalVisible;
            listVisible = !listVisible;
        }

        private void ToggleEditar() 
        {
            ModalEditar = !ModalEditar;
            listVisible = !listVisible;
        }

        private void ToggleJuegos()
        {
            listaJuegos = !listaJuegos;
            listVisible = !listVisible;
        }



        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }








        private string _nombre;
        private string _fabricante;
        private string _enlaceimagen;
        private int _consolaid;

        public string Nombre
        {
            get => _nombre;
            set { _nombre = value; OnPropertyChanged(nameof(Nombre)); }
        }

        public string Fabricante
        {
            get => _fabricante;
            set { _fabricante = value; OnPropertyChanged(nameof(Fabricante)); }
        }

        public string EnlaceImagen
        {
            get => _enlaceimagen;
            set { _enlaceimagen = value; OnPropertyChanged(nameof(EnlaceImagen)); }
        }
        public int ConsolaId
        {
            get => _consolaid;
            set { _consolaid = value; OnPropertyChanged(nameof(ConsolaId)); }
        }

        public ObservableCollection<ItemConsolas> ListaConsolas { get; set; } = new ObservableCollection<ItemConsolas>();
        public ObservableCollection<Item_juego_consola> ListaJuegosConsolas { get; set; } = new ObservableCollection<Item_juego_consola
            >();
    }
}
