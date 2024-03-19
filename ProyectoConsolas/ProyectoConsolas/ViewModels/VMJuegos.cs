using htt.Models;
using ProyectoConsolas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProyectoConsolas.ViewModels
{
    public class VMJuegos
    {
        public VMJuegos() {
            getJuegos();
        }

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

        public ObservableCollection<ItemJuegos> listaJuegos { get; set; } = new ObservableCollection<ItemJuegos>();
    }
}
