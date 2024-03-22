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
            GetConsolas();
            ToggleListaJuegosCommand = new Command(ToggleJuegos);
            ToggleEditarCommand = new Command(ToggleEditar);
            ToggleModalCommand = new Command(ToggleModal);
            ToggleAgregarJuegoCommand = new Command(ToggleAgregarJuego);

            RegistrarConsolaCommand = new Command(async () => await RegistrarConsolaAsync());
            AsignarJuegoCommand = new Command(async () => await )
            ActualizarConsolaCommand = new Command(async () => await ActualizarConsolaAsync());
            EliminarConsolaCommand = new Command<ItemConsolas>(async (consola) => await EliminarConsolaAsync(consola.consolaid));
            EditarConsolaCommand = new Command<ItemConsolas>(EditarConsola);
            JuegosConsolaCommand = new Command<ItemConsolas>(async (consola) => await GetJuegosConsolas(consola.consolaid));
            ConsolaSelectedCommand = new Command<ItemConsolas>((consola) => ConsolaSeleccionadaId = consola.consolaid);
            FechaLanzamiento = DateTime.Today;
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
        public ICommand ConsolaSelectedCommand { get; private set; }
        public ICommand AsignarJuegoCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;


        private bool _listVisible = true;
        private bool _isModalVisible = false;
        private bool _modalEditar = false;
        private bool _listaJuegos = false;
        private bool _agregarJuego = false;
        private string _juegoSeleccionado;
        public string JuegoSeleccionado
        {
            get => _juegoSeleccionado;
            set
            {
                _juegoSeleccionado = value;
                OnPropertyChanged(nameof(JuegoSeleccionado));
            }
        }


        private int _consolaSeleccionadaId;
        public int ConsolaSeleccionadaId
        {
            get => _consolaSeleccionadaId;
            set
            {
                if (_consolaSeleccionadaId != value)
                {
                    _consolaSeleccionadaId = value;
                    OnPropertyChanged(nameof(ConsolaSeleccionadaId));
                }
                ToggleAgregarJuego();
            }

        }
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

        public bool agregarJuego
        {
            get { return _agregarJuego; }
            set
            {
                _agregarJuego = value;
                OnPropertyChanged(nameof(agregarJuego));
            }
        }


        public ICommand ToggleModalCommand { get; private set; }
        public ICommand ToggleEditarCommand { get; private set; }
        public ICommand ToggleListaJuegosCommand { get; private set; }
        public ICommand ToggleAgregarJuegoCommand { get; private set; }

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

        private async Task AsignarConsolaAsync()
        {
            string url = "https://apex.oracle.com/pls/apex/juegos/api/examen/consolas/juegos";
            ConsumoServicios servicios = new ConsumoServicios(url);

            AsignarConsola nuevoRegistro = new AsignarConsola
            {
                consolaid = ConsolaSeleccionadaId,
                videojuegoid = (JuegoSeleccionado)
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

        private async Task EliminarConsolaAsync(int id)
        {
            bool confirmar = await Application.Current.MainPage.DisplayAlert(
                "Confirmar",
                "¿Seguro que quieres eliminar este registro?",
                "OK",
                "Cancelar" 
            );
            if (confirmar)
            {
                string url = $"https://apex.oracle.com/pls/apex/juegos/api/examen/consolas?consolaid={id}";

                try
                {
                    ConsumoServicios servicios = new ConsumoServicios(url);
                    var response = await servicios.DeleteAsync<RegistroConsolas>();
                    await Application.Current.MainPage.DisplayAlert("Éxito", "El registro ha sido eliminado exitosamente.", "OK");
                    GetConsolas();
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", $"Error al eliminar el registro: {ex.Message}", "OK");
                }
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

        private void ToggleAgregarJuego()
        {
            agregarJuego = !agregarJuego;
            listVisible = !listVisible;

            getJuegos();
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


        private async void getJuegos()
        {
            listaJuegosParaAgregar.Clear();
            string url = "https://apex.oracle.com/pls/apex/juegos/api/examen/videojuegos";

            ConsumoServicios servicios = new ConsumoServicios(url);

            var response = await servicios.Get<JuegosResponse>();
            foreach (ItemJuegos x in response.items)
            {
                ItemJuegos temp = new ItemJuegos()
                {
                    id = x.id,
                    titulo = x.titulo,
                    fechalanzamiento = x.fechalanzamiento
                };

                listaJuegosParaAgregar.Add(temp);
            }

        }

        public ObservableCollection<ItemJuegos> listaJuegosParaAgregar { get; set; } = new ObservableCollection<ItemJuegos>();

        public ObservableCollection<ItemConsolas> ListaConsolas { get; set; } = new ObservableCollection<ItemConsolas>();
        public ObservableCollection<Item_juego_consola> ListaJuegosConsolas { get; set; } = new ObservableCollection<Item_juego_consola>();
    }
}
