﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoConsolas.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ItemJuegos
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string fechalanzamiento { get; set; }
    }

    public class LinkJuegos
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class JuegosResponse
    {
        public List<ItemJuegos> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<LinkJuegos> links { get; set; }
    }


}
