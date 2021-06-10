using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Clases
{
    class Regalo : Opcionales
    {
        public override string descripcion { get
            {
                return "Envolver en papel de regalo";
            }
        }
        public override double CalcularCosto(double precio)
        {
            if (precio >= 5000 )
            {
                return 750;
            }
            else
            {
                return 500;
            }
        }
    }
}
