using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoConsolas.Models
{
    public class RegistroConsolas
    {
        internal int consolaid;

        public string nombre { get; set; }
        public string fabricante { get; set; }
        public string fechalanzamiento { get; set; }
        public string enlaceimagen { get; set; }
    } 
}
