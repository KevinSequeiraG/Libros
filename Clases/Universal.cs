using Libros.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Clases
{
    class Universal : ITienda
    {
        public string Nombre
        {
            get
            {
                return "Universal";
            }
        }
        public float PorcentajeGanancia
        {
            get
            {
                return 0.132f;
            }
        }

    }
}
