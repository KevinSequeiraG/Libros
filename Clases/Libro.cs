using Libros.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Clases
{
    class Libro
    {
        public Editorial editorial { get; set; }
        public Genero genero { get; set; }
        public double precio { get; set; }
        public string titulo { get; set; } 

    }
}
