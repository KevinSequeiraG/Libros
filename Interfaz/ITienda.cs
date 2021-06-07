using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Interfaz
{
    interface ITienda
    {
        string Nombre { get; }
        float PorcentajeGanancia { get; }
    }
}
