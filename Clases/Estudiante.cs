using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Clases
{
    class Estudiante : Opcionales
    {
        public override string descripcion
        {
            get
            {
                return "Aplicar descuento de estudiante";
            }
        }
        public override double CalcularCosto(double precio)
        {
            return - (precio * 0.05);
        }
    }
}
