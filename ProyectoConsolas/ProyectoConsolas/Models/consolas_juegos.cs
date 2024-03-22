using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoConsolas.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Item_juego_consola
    {
        public int cv_id { get; set; }
        public int consolaid { get; set; }
        public int videojuegoid { get; set; }
        public string titulo_consola { get; set; }
        public string titulo_videojuego { get; set; }
    }

    public class Link_juego_consola
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class Response_juego_consola
    {
        public List<Item_juego_consola> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Item_juego_consola> links { get; set; }
    }


}
