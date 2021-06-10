using Libros.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Clases
{
    class Internacional : ITienda
    {
        public string Nombre
        {
            get
            {
                return "Internacional";
            }
        }

        public float PorcentajeGanancia {
            get
            {
                return 0.167f;
            }
        }
    }
}
