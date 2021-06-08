using Libros.Clases;
using Libros.Enums;
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

        public FacturaFacade()
        {
            fecha = new DateTime();
            opcionales = new List<Opcionales>();
            numeroFactura = fecha.Ticks;
        }

        public void AgregarCliente(string nombre, string correo, int telefono)
        {
            cliente = new Cliente();

            cliente.correo = correo;
            cliente.nombre = nombre;
            cliente.telefono = telefono;
        }

        public void AgregarLibro(string titulo, double precio, Genero genero, Editorial editorial)
        {
            libro = new Libro();

            libro.editorial = editorial;
            libro.genero = genero;
            libro.precio = precio;
            libro.titulo = titulo;
        }
        public void AgregarOpcionales(Opcionales op)
        {
            opcionales.Add(op);
        }

        public double CalcularTotal()
        {
            double tot = libro.CalcularCosto() * cantidad;
            if (tienda is Lehmann)
            {
                tot += tot * ((Lehmann)tienda).PorcentajeGanancia;
            }
            else if (tienda is Universal)
            {
                tot += tot * ((Universal)tienda).PorcentajeGanancia;
            }else
            {
                tot += tot * ((Internacional)tienda).PorcentajeGanancia;
            }

            return tot;
        }

        public void Guardar(string ruta)
        {

        }

        public List<Editorial> ObtenerEditoriales()
        {
            List<Editorial> lista = new List<Editorial>();

            return lista;
        }
    }
}
