using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;


namespace Pantallas
{
    public partial class FrmAltaArticulo : Form
    {
        private Articulo seleccionado = null;

        public FrmAltaArticulo()
        {
            InitializeComponent();
        }

        public FrmAltaArticulo(Articulo seleccionado)
        {
            InitializeComponent();
            this.seleccionado = seleccionado;
            Text = "Modificar artículo";
        }

        private void AltaArticulo_Load(object sender, EventArgs e)
        {
            NegocioCategoria nuevaCategoría = new NegocioCategoria();
            NegocioMarca nuevaMarca = new NegocioMarca();

            try
            {
                cbCategoria.DataSource = nuevaCategoría.listarCategoria();
                cbCategoria.ValueMember = "Id";
                cbCategoria.DisplayMember = "Descripcion";

                cbMarca.DataSource = nuevaMarca.listarMarca();
                cbMarca.ValueMember = "Id";
                cbMarca.DisplayMember = "Descripcion";
               
                if (seleccionado != null)
                {
                    txtbCodigo.Text = seleccionado.Codigo;
                    txtbNombre.Text = seleccionado.Nombre;
                    txtbDescripcion.Text = seleccionado.Descripcion;
                    txtbPrecio.Text = seleccionado.Precio.ToString();
                    txtbUrlImagen.Text = seleccionado.ImagenUrl;
                    cargarImagen(seleccionado.ImagenUrl);
                    cbMarca.SelectedValue = seleccionado.Marca.Id;
                    cbCategoria.SelectedValue = seleccionado.Categoria.Id;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            NegocioArticulo negocio = new NegocioArticulo();

            try
            {
                if (ValidarVacio())
                    return;

                if (seleccionado == null)
                    seleccionado = new Articulo();

                seleccionado.Codigo = txtbCodigo.Text;
                seleccionado.Nombre = txtbNombre.Text;
                seleccionado.Descripcion = txtbDescripcion.Text;
                seleccionado.Marca = (Marca)cbMarca.SelectedItem;
                seleccionado.Categoria = (Categoria)cbCategoria.SelectedItem;
                seleccionado.ImagenUrl = txtbUrlImagen.Text;
                seleccionado.Precio = decimal.Parse(txtbPrecio.Text);
                            
                if (seleccionado.Id != 0)
                {
                    negocio.modificar(seleccionado);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocio.agregar(seleccionado);
                    MessageBox.Show("Agregado exitosamente");
                }
                              
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtbUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtbUrlImagen.Text);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbImagen.Load(imagen);
            }
            catch (Exception)
            {
                pbImagen.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");
            }

        }

        private bool ValidarVacio()
        {
            try
            {
                if (string.IsNullOrEmpty(txtbCodigo.Text))
                {
                    MessageBox.Show("Se requiere completar el campo código");
                    return true;
                }

                if (string.IsNullOrEmpty(txtbNombre.Text))
                {
                    MessageBox.Show("Se requiere completar el campo nombre");
                    return true;
                }

                if (string.IsNullOrEmpty(txtbPrecio.Text))
                {
                    MessageBox.Show("Se requiere completar el campo precio");
                    return true;
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return false;
        }

        private void txtbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
                    e.Handled = true;

                if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }           
        }
    }
}
