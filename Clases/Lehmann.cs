using Libros.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Clases
{
    class Lehmann : ITienda
    {
        public string Nombre
        {
            get
            {
                return "Lehmann";
            }
        }
        public float PorcentajeGanancia { get; }
    }
}
