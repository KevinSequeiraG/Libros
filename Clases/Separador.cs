using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Clases
{
    class Separador : Opcionales
    {
        public override string descripcion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override double CalcularCosto(double precio)
        {
            if (precio >= 10000)
            {
                return 0;
            }
            else
            {
                return 300;
            }
        }
    }
}
