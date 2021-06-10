using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Clases
{
    abstract class Opcionales
    {
        abstract public string descripcion { get; }
        abstract public double CalcularCosto(double precio);
    }
}
