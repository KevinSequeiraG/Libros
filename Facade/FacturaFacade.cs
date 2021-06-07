using Libros.Clases;
using Libros.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Facade
{
    class FacturaFacade
    {
        Cliente cliente;
        DateTime fecha;
        Libro libro;
        long numeroFactura;
        List<Opcionales> opcionales;
        public int cantidad { get; set; }
        public ITienda tienda{ get; set; }
    }
}
