using Libros.Clases;
using Libros.Enums;
using Libros.Facade;
using Libros.Factory;
using Libros.Interfaz;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libros
{
    public partial class frmPrincipal : Form
    {
        FacturaFacade factura;
        Opcionales opc;
        TiendaFactory tienda;
        string rutaXml;
        public frmPrincipal()
        {
            
            InitializeComponent();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {                             
            try
            {
                tienda = new TiendaFactory();
                
                factura = new FacturaFacade();
                factura.tienda = tienda.CrearTienda(rbtUniversal.Checked, rbtLehmann.Checked, rbtInternacional.Checked);
                factura.AgregarCliente(txtNombre.Text, txtEmail.Text, int.Parse(mtxTelefono.Text));
                factura.AgregarLibro(txtTitulo.Text, double.Parse(txtPrecio.Text), (Genero)cmbGenero.SelectedItem, (Editorial)cmbEditorial.SelectedItem);
                factura.cantidad = int.Parse(nudCantidad.Value.ToString());
                if (chkEstudiante.Checked)
                {
                    opc = new Estudiante();
                    factura.AgregarOpcionales(opc);
                }
                if (chkRegalo.Checked)
                {
                    opc = new Regalo();
                    factura.AgregarOpcionales(opc);
                }
                if (chkSeparador.Checked)
                {
                    opc = new Separador();
                    factura.AgregarOpcionales(opc);
                }
                if (factura != null)
                {
                    saveFileDialog.Filter = "Solo XML | *.xml";
                    DialogResult resultado = saveFileDialog.ShowDialog();
                    if (resultado == System.Windows.Forms.DialogResult.OK)
                    {
                        rutaXml = saveFileDialog.FileName;
                        factura.Guardar(rutaXml);

                        string rutaHtml = Application.StartupPath + "\\" + "factura.html";

                        factura.convertToHTML(rutaXml, rutaHtml);

                        // modo 1: mostrar en WebBrowser
                        webBrowser.Url = new Uri(rutaHtml);
                    }
                }
                else
                {
                    MessageBox.Show("Primero debe crear la orden de compra", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                factura = new FacturaFacade();
                List <Editorial> editorials = factura.ObtenerEditoriales();
                cmbGenero.DataSource = Enum.GetValues(typeof(Genero));
                foreach (Editorial item in editorials)
                {
                    cmbEditorial.Items.Add(item);
                }                
                cmbEditorial.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 2500))
                {
                    MessageBox.Show("Debe ingresar solamente numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }            
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar > 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
                {
                    MessageBox.Show("Debe ingresar solo letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }            
        }
    }
}
