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
    public partial class FrmCatalogo : Form
    {
        private List<Articulo> listaArticulos;
        public FrmCatalogo()
        {
            InitializeComponent();
        }

        private void FrmCatalogo_Load(object sender, EventArgs e)
        {
            cargarGrilla();
           
            cbFiltroCampo.Items.Add("Nombre");
            cbFiltroCampo.Items.Add("Marca");
            cbFiltroCampo.Items.Add("Categoría");
            cbFiltroCampo.Items.Add("Precio");

        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.CurrentRow != null)
                {
                    Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    cargarImagen(seleccionado.ImagenUrl);
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }

        private void cargarGrilla()
        {
            NegocioArticulo negocio = new NegocioArticulo();

            try
            {
                listaArticulos = negocio.listar();
                dgvArticulos.DataSource = listaArticulos;
                ocultarColumnas();
                cargarImagen(listaArticulos[0].ImagenUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbImagenArticulo.Load(imagen);
            }
            catch (Exception)
            {
                pbImagenArticulo.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaArticulo alta = new FrmAltaArticulo();
            alta.ShowDialog();
            cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            FrmAltaArticulo modificar = new FrmAltaArticulo(seleccionado);
            modificar.ShowDialog();
            cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            NegocioArticulo negocio = new NegocioArticulo();

            try
            {
                DialogResult respuesta = MessageBox.Show("¿Estás seguro de eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado.Id);
                    cargarGrilla();
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtbFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;

            try
            {                            
                if (txtbFiltroRapido.Text != "")
                    listaFiltrada = listaArticulos.FindAll(x => x.Codigo.ToUpper().Contains(txtbFiltroRapido.Text.ToUpper()) || x.Nombre.ToUpper().Contains(txtbFiltroRapido.Text.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(txtbFiltroRapido.Text.ToUpper()) || x.Categoria.Descripcion.ToUpper().Contains(txtbFiltroRapido.Text.ToUpper()));
                else
                    listaFiltrada = listaArticulos;

                dgvArticulos.DataSource = null;
                dgvArticulos.DataSource = listaFiltrada;
                ocultarColumnas();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }          
        }

        private void ocultarColumnas()
        {
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;
        }

        private void cbFiltroCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiltroCampo.SelectedItem.ToString() == "Precio")
            {
                cbFiltroCriterio.Items.Clear();
                cbFiltroCriterio.Items.Add("Mayor a");
                cbFiltroCriterio.Items.Add("Menor a");
                cbFiltroCriterio.Items.Add("Igual a");
            }
            else
            {
                cbFiltroCriterio.Items.Clear();
                cbFiltroCriterio.Items.Add("Comienza con");
                cbFiltroCriterio.Items.Add("Termina con");
                cbFiltroCriterio.Items.Add("Contiene");
            }
        }

        private void btnFiltroAvanzado_Click(object sender, EventArgs e)
        {
            NegocioArticulo negocio = new NegocioArticulo();

            try
            {
                if (validarFiltro())
                    return;

                string campo = cbFiltroCampo.SelectedItem.ToString();
                string criterio = cbFiltroCriterio.SelectedItem.ToString();
                string filtro = txtbFiltroAvanzado.Text;

                dgvArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool validarFiltro()
        {
            try
            {
                if (cbFiltroCampo.SelectedIndex < 0)
                {
                    MessageBox.Show("Se requiere seleccionar campo para filtrar");
                    return true;
                }

                if (cbFiltroCriterio.SelectedIndex < 0)
                {
                    MessageBox.Show("Se requiere seleccionar criterio para filtrar");
                    return true;
                }

                if (cbFiltroCampo.SelectedItem.ToString() == "Precio")
                {
                    if (!(soloNumeros(txtbFiltroAvanzado.Text)))
                    {
                        MessageBox.Show("Sólo ingresar números para filtar por campo Precio");
                        return true;
                    }
                } 
                
                if (string.IsNullOrEmpty(txtbFiltroAvanzado.Text))
                {
                    MessageBox.Show("Se requiere cargar el filtro");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return false;
        }

        private bool soloNumeros(string cadena)
        {
            try
            {
                foreach (char caracter in cadena)
                {
                    if (!(char.IsNumber(caracter)))
                        return false;
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return true;
        }       
    }
}
