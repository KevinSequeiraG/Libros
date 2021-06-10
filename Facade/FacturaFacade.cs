using Libros.Clases;
using Libros.Enums;
using Libros.Interfaz;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

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
        public ITienda tienda { get; set; }

        public FacturaFacade()
        {
            fecha = DateTime.Now;
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
            double totTienda = 0;
            if (tienda is Lehmann)
            {
                totTienda = libro.precio * ((Lehmann)tienda).PorcentajeGanancia;
            }
            else if (tienda is Universal)
            {
                totTienda = libro.precio * ((Universal)tienda).PorcentajeGanancia;
            }
            else
            {
                totTienda = libro.precio * ((Internacional)tienda).PorcentajeGanancia;
            }
            foreach (var item in opcionales)
            {
                totTienda += item.CalcularCosto(libro.precio);
            }
            return Math.Round((libro.precio + totTienda + libro.CalcularCosto())*cantidad);
        }

        public void Guardar(string ruta)
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                if (File.Exists(ruta) == false)
                {
                    doc.LoadXml("<Facturas></Facturas>");
                    
                }
                else
                { 
                    doc.Load(ruta);
                }
                XmlElement root = doc.DocumentElement;

                XmlElement newRegistro = doc.CreateElement("Factura");
                newRegistro.SetAttribute("Numero", numeroFactura.ToString());
                newRegistro.SetAttribute("Fecha", fecha.ToShortDateString());
                newRegistro.SetAttribute("Total", CalcularTotal().ToString());

                XmlElement nodoTienda = doc.CreateElement("Tienda");
                nodoTienda.SetAttribute("Nombre", tienda.Nombre);
                newRegistro.AppendChild(nodoTienda);

                XmlElement nodoCliente = doc.CreateElement("Cliente");
                nodoCliente.SetAttribute("Telefono", cliente.telefono.ToString());
                newRegistro.AppendChild(nodoCliente);

                XmlElement nodoNombre = doc.CreateElement("Nombre");
                nodoNombre.InnerText = cliente.nombre;
                nodoCliente.AppendChild(nodoNombre);

                XmlElement nodoEmail = doc.CreateElement("Email");
                nodoEmail.InnerText = cliente.correo;
                nodoCliente.AppendChild(nodoEmail);

                XmlElement nodoLibro = doc.CreateElement("Libro");
                nodoLibro.SetAttribute("Titulo", libro.titulo);
                nodoLibro.SetAttribute("Precio", libro.precio.ToString());
                nodoLibro.SetAttribute("Cantidad", cantidad.ToString());
                newRegistro.AppendChild(nodoLibro);

                XmlElement nodoGenero = doc.CreateElement("Genero");
                nodoGenero.InnerText = libro.genero.ToString();
                nodoLibro.AppendChild(nodoGenero);

                XmlElement nodoEditorial = doc.CreateElement("Editorial");
                nodoEditorial.InnerText = libro.editorial.ToString();
                nodoLibro.AppendChild(nodoEditorial);

                XmlElement nodoOpcionales = doc.CreateElement("Opcionales");
                newRegistro.AppendChild(nodoOpcionales);

                foreach (Opcionales op in opcionales)
                {
                    XmlElement nodoOpcional = doc.CreateElement("Opcional");
                    nodoOpcional.InnerText = op.descripcion;
                    nodoOpcionales.AppendChild(nodoOpcional);
                }

                root.AppendChild(newRegistro);

                doc.Save(ruta);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al guardar - "+ex.Message);
            }
        }

        public List<Editorial> ObtenerEditoriales()
        {
            List<Editorial> lista = new List<Editorial>();

            using (StreamReader archivo = File.OpenText(Application.StartupPath + "\\Json\\Editoriales.json"))
            {
                string json = archivo.ReadToEnd();

                var arrayJson = JsonConvert.DeserializeObject<List<Editorial>>(json);

                foreach (Editorial conjunto in arrayJson)
                {
                    lista.Add(new Editorial { Nombre = conjunto.Nombre, PorcentajeComision = conjunto.PorcentajeComision });
                }
            }
            return lista;
        }

        public void convertToHTML(string rutaXML, string rutaHtml)
        {
            string rutaXslt = Application.StartupPath + "\\Xslt\\Libros.xslt";
            // Transformación del XMl utilizando XSLT
            XslCompiledTransform myXslTrans = new XslCompiledTransform();
            // Carga en memoria la lectura xslt
            myXslTrans.Load(rutaXslt);
            // Transforma el archivo xml aun archivo HTML
            myXslTrans.Transform(rutaXML, rutaHtml);
        }
    }
}
