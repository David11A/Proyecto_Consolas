using System;
using ProyectoConsolas.Models;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using Xamarin.Forms;

namespace ProyectoConsolas.ViewModels
{
    public class VMConsolas : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isModalVisible = false;

        public bool IsModalVisible
        {
            get { return _isModalVisible; }
            set
            {
                _isModalVisible = value;
                OnPropertyChanged(nameof(IsModalVisible)); 
            }
        }


        public ICommand ToggleModalCommand { get; private set; }

        public VMConsolas()
        {
            ToggleModalCommand = new Command(ToggleModal); 
            GetConsolas();
        }

        private async void GetConsolas()
        {
            string url = "https://apex.oracle.com/pls/apex/juegos/api/examen/consolas";

            ConsumoServicios servicios = new ConsumoServicios(url);

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

        private void ToggleModal()
        {
            IsModalVisible = !IsModalVisible;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<ItemConsolas> ListaConsolas { get; set; } = new ObservableCollection<ItemConsolas>();
    }
}
