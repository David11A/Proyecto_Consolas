using System;
using ProyectoConsolas.Models;
using System.Collections.Generic;
using System.Text;
using htt.Models;
using System.Collections.ObjectModel;

namespace ProyectoConsolas.ViewModels
{
    public class Consolas
    {
        public Consolas() {
            getConsolas();
        }

        private async void getConsolas()
        {
            string url = "https://apex.oracle.com/pls/apex/juegos/api/examen/consolas";

            ConsumoServicios servicios = new ConsumoServicios(url);

            var response = await servicios.Get<ConsolasResponse>();
            foreach(ItemConsolas x in response.items)
            {
                ItemConsolas temp = new ItemConsolas()
                {
                    consolaid = x.consolaid,
                    nombre = x.nombre,
                    fabricante = x.fabricante,
                    fechalanzamiento = x.fechalanzamiento,
                    enlaceimagen = x.enlaceimagen
                };

                listaConsolas.Add(temp);
            }

        }

        public ObservableCollection<ItemConsolas> listaConsolas { get; set; } = new ObservableCollection<ItemConsolas>();
    }
}
