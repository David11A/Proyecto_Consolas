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
        }

        private bool _modalRegistro=false;
        private bool _listaJuegosVisible  =true;

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


        public ICommand ToggleModalRegistroCommand { get; set; }


        private async void getJuegos()
        {
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

        public ObservableCollection<ItemJuegos> listaJuegos { get; set; } = new ObservableCollection<ItemJuegos>();
    }
}
