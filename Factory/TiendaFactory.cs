using Libros.Clases;
using Libros.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Factory
{
    class TiendaFactory
    {
        public ITienda CrearTienda(bool universal, bool lehmann, bool internacional)
        {
            ITienda tienda;
            if (universal)
            {
                tienda = new Universal();
            }
            else if (lehmann)
            {
                tienda = new Lehmann();
            }
            else
            {
                tienda = new Internacional();
            }
            return tienda;
        }
    }
}
