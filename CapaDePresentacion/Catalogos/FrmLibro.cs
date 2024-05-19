using CapaDeNegocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDePresentacion.Catalogos
{
    public partial class FrmLibro : Form
    {
        //Variables
        private LibroCN libroCN;
        private CategoriaCN categoriaCN = new CategoriaCN();
        private Libro libro;
        private bool editar = false;
        private int libroid;

        public FrmLibro()
        {
            InitializeComponent();
        }

        private void FrmLibro_Load(object sender, EventArgs e)
        {
            Mostrar();
            CargarDatos();
        }

        //Obtener los libros desde la Capa de Negocio y la vamos a enviar al DGV
        private void Mostrar()
        {
            try
            {
                libroCN = new LibroCN();
                DgvLibros.DataSource = libroCN.Obtener();
                DgvLibros.Columns["Id"].Visible = false;
                DgvLibros.Columns["CategoriaId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Cargar los datos que vamos a necesitar en el formulario
        private void CargarDatos()
        {
            try
            {
                CmbCategoria.DataSource = categoriaCN.ObtenerCategorias();
                CmbCategoria.DisplayMember = "Descripcion";
                CmbCategoria.ValueMember = "Id";
                CmbCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Limpiar los controles de texto
        private void LimpiarDatos()
        {
            TxtCodigo.Text = "";
            TxtTitulo.Text = "";
            TxtISBN.Text = "";
            TxtAutor.Text = "";
            CmbCategoria.SelectedIndex = -1;
            
            TxtCodigo.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Si es nuevo
                if (editar == false)
                {

                    libro = new Libro(0, TxtCodigo.Text, TxtTitulo.Text,TxtISBN.Text,TxtAutor.Text,(int)CmbCategoria.SelectedValue);

                    //libroCN.ValidarAntesDeCrear(libro);

                    if (libroCN.Insertar(libro))
                    {
                        LimpiarDatos();
                        Mostrar();
                    }
                    else
                        MessageBox.Show("El registro no se inserto correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else //Es uno existente
                {
                    editar = false;
                    libro = new Libro(libroid, TxtCodigo.Text, TxtTitulo.Text, TxtISBN.Text, TxtAutor.Text, (int)CmbCategoria.SelectedValue);

                    //libroCN.ValidarAntesDeEditar(libro);

                    if (libroCN.Editar(libro))
                    {
                        LimpiarDatos();
                        Mostrar();
                    }
                    else
                        MessageBox.Show("El registro no se edito correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvLibros.SelectedRows.Count > 0)
                {
                    editar = true;

                    TxtCodigo.Text = "";
                    TxtTitulo.Text = "";
                    TxtISBN.Text = "";
                    TxtAutor.Text = "";
                    CmbCategoria.SelectedIndex = -1;

                    TxtCodigo.Text = DgvLibros.CurrentRow.Cells["Codigo"].Value.ToString();
                    TxtTitulo.Text = DgvLibros.CurrentRow.Cells["Titulo"].Value.ToString();
                    TxtISBN.Text = DgvLibros.CurrentRow.Cells["ISBN"].Value.ToString();
                    TxtAutor.Text = DgvLibros.CurrentRow.Cells["Autor"].Value.ToString();
                    CmbCategoria.SelectedValue = DgvLibros.CurrentRow.Cells["CategoriaId"].Value.ToString();
                    libroid = int.Parse(DgvLibros.CurrentRow.Cells["Id"].Value.ToString());

                }
                else
                    MessageBox.Show("Debe seleccionar una fila de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvLibros.SelectedRows.Count > 0)
                {
                    libroid = int.Parse(DgvLibros.CurrentRow.Cells["Id"].Value.ToString());

                    //libroCN.ValidarAntesDeEliminar(libroid);

                    if (libroCN.Eliminar(libroid))
                    {
                        LimpiarDatos();
                        Mostrar();
                    }
                    else
                        MessageBox.Show("El registro no se elimino correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Debe seleccionar una fila de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
