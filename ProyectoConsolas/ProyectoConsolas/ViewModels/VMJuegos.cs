using ProyectoConsolas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoConsolas.ViewModels
{
    public class VMJuegos : INotifyPropertyChanged
    {
        public VMJuegos() {
            getJuegos();
            ToggleModalRegistroCommand = new Command(ToggleModalRegistro);
            ToggleModalEdidarCommand = new Command(ToggleEditarJuego);
            RegistrarJuegoCommand = new Command(async () => await RegistrarJuegoAsync());
            ActualizarJuegoCommand = new Command(async () => await ActualizarJuegoAsync());
            EditarJuegoCommand = new Command<ItemJuegos>(EditarJuego);
            EliminarJuegoCommand = new Command<ItemJuegos>(async (videojuego) => await EliminarJuegoaAsync(videojuego.id));
            FechaLanzamiento = DateTime.Today;
        }

        private bool _modalRegistro = false;
        private bool _modalEditar = false;
        private bool _listaJuegosVisible = true;

        public bool IsModalRegistroVisible
        {
            get { return _modalRegistro; }
            set
            {
                _modalRegistro = value;
                OnPropertyChanged(nameof(IsModalRegistroVisible));
            }
        }

        public bool IsListaJuegosVisible
        {
            get { return _listaJuegosVisible; }
            set
            {
                _listaJuegosVisible = value;
                OnPropertyChanged(nameof(IsListaJuegosVisible));
            }
        }
        private ItemJuegos _juegoEditado;
        public ItemJuegos JuegoEditado
        {
            get => _juegoEditado;
            set
            {
                _juegoEditado = value;
                OnPropertyChanged(nameof(JuegoEditado));
            }
        }

        public bool IsModalEditarVisible
        {
            get { return _modalEditar; }
            set
            {
                _modalEditar = value;
                OnPropertyChanged(nameof(IsModalEditarVisible));
            }
        }

        private void EditarJuego(ItemJuegos juego)
        {
            JuegoEditado = new ItemJuegos
            {
                id = juego.id,
                titulo = juego.titulo,
                fechalanzamiento = juego.fechalanzamiento,
            };
            FechaLanzamiento = DateTime.Parse(juego.fechalanzamiento);
            ToggleEditarJuego();
        }

        public ICommand RegistrarJuegoCommand { get; private set; }
        public ICommand ToggleModalRegistroCommand { get; set; }
        public ICommand ToggleModalEdidarCommand { get; set; }
        public ICommand ActualizarJuegoCommand { get; private set; }
        public ICommand EliminarJuegoCommand { get; private set; }
        public ICommand EditarJuegoCommand { get; private set; }


        private async void getJuegos()
        {
            listaJuegos.Clear();
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

                listaJuegos.Add(temp);
            }

        }


        private async Task RegistrarJuegoAsync()
        {
            string url = "https://apex.oracle.com/pls/apex/juegos/api/examen/videojuegos";
            ConsumoServicios servicios = new ConsumoServicios(url);

            RegistroVideojuegos nuevaConsola = new RegistroVideojuegos
            {
                titulo = Titulo,
                fechalanzamiento = FechaLanzamiento.ToString("yyyy-MM-dd"),

            };

            try
            {
                var response = await servicios.PostAsync<RegistroConsolas>(nuevaConsola);
                await Application.Current.MainPage.DisplayAlert("Éxito", "El juego se ha registrado exitosamente.", "Ok");
                getJuegos();
                IsModalRegistroVisible = false;
                IsListaJuegosVisible = true;
            }
            catch (Exception ex)
            {
                // En caso de error, mostramos un alert.
                await Application.Current.MainPage.DisplayAlert("Error", "Error al registrar la consola: " + ex.Message, "Ok");
            }
        }
        private async Task ActualizarJuegoAsync()
        {
            int id = JuegoEditado.id;

            string url = $"https://apex.oracle.com/pls/apex/juegos/api/examen/videojuegos?id={id}";
            ConsumoServicios servicios = new ConsumoServicios(url);
            RegistroVideojuegos juegoActualizado = new RegistroVideojuegos
            {
                titulo = JuegoEditado.titulo,
                fechalanzamiento = JuegoEditado.fechalanzamiento.ToString()
            };

            try
            {
                var response = await servicios.PutAsync<RegistroVideojuegos>(juegoActualizado);
                await Application.Current.MainPage.DisplayAlert("Éxito", "Se actualizo exitosamente.", "OK");
                getJuegos();
                JuegoEditado = new ItemJuegos();
                IsModalEditarVisible = false;
                IsListaJuegosVisible = true;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error al actualizar la consola: {ex.Message}", "OK");
            }
            Console.WriteLine(juegoActualizado.ToString());
        }


        private async Task EliminarJuegoaAsync(int id)
        {
            bool confirmar = await Application.Current.MainPage.DisplayAlert(
                "Confirmar",
                "¿Seguro que quieres eliminar este registro?",
                "OK",
                "Cancelar"
            );
            if (confirmar)
            {
                string url = $"https://apex.oracle.com/pls/apex/juegos/api/examen/videojuegos?id={id}";
                try
                {
                    ConsumoServicios servicios = new ConsumoServicios(url);
                    var response = await servicios.DeleteAsync<RegistroVideojuegos>();
                    await Application.Current.MainPage.DisplayAlert("Éxito", "El registro ha sido eliminado exitosamente.", "OK");
                    getJuegos();
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", $"Error al eliminar el registro: {ex.Message}", "OK");
                }
            }

        }






        private void ToggleModalRegistro()
        {
            IsModalRegistroVisible = !IsModalRegistroVisible;
            IsListaJuegosVisible = !IsListaJuegosVisible;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ToggleEditarJuego()
        {
            IsModalEditarVisible = !IsModalEditarVisible;
            IsListaJuegosVisible = !IsListaJuegosVisible;
        }
        public int idGlobalEditar;
        private string _titulo;
        private DateTime _fechaLanzamiento;

        public string Titulo
        {
            get => _titulo;
            set { _titulo = value; OnPropertyChanged(nameof(Titulo)); }
        }

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
        public ObservableCollection<ItemJuegos> listaJuegos { get; set; } = new ObservableCollection<ItemJuegos>();
    }
}
