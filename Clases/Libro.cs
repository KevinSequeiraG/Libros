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

        public double CalcularCosto()
        {
            double totGenero = 0;
            double totEditorial = precio * (editorial.PorcentajeComision / 100);
            switch (genero)
            {
                case Genero.Novela:
                    totGenero = precio * 0.035;
                    break;
                case Genero.Cuento:
                    totGenero = precio * 0.047;
                    break;
                case Genero.Comics:
                    totGenero = precio * 0.058;
                    break;
            }
            return totGenero + totEditorial;
        }
    }
}
