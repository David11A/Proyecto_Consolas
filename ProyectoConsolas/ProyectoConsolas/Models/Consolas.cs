using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoConsolas.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ItemConsolas
    {
        public int consolaid { get; set; }
        public string nombre { get; set; }
        public string fabricante { get; set; }
        public DateTime fechalanzamiento { get; set; }
        public string enlaceimagen { get; set; }
    }

    public class LinkConsolas
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class ConsolasResponse
    {
        public List<ItemConsolas> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<LinkConsolas> links { get; set; }
    }


}
