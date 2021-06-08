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
            double tot = 0;
            switch (genero)
            {
                case Genero.Novela:
                    tot = precio + (precio * 0.035);
                    break;
                case Genero.Cuento:
                    tot = precio + (precio * 0.047);
                    break;
                case Genero.Comics:
                    tot = precio + (precio * 0.058);
                    break;
            }

            return tot + (tot * (editorial.PorcentajeComision/100));
        }
    }
}
