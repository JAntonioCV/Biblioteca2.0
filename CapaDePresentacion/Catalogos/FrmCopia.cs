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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaDePresentacion.Catalogos
{
    public partial class FrmCopia : Form
    {

        //Variables
        private CopiaCN copiaCN;
        private LibroCN libroCN = new LibroCN();
        private Copia copia;
        private bool editar = false;
        private int copiaId;
        public bool esPrestada;

        public FrmCopia()
        {
            InitializeComponent();
        }

        private void FrmCopia_Load(object sender, EventArgs e)
        {
            Mostrar();
            CargarDatos();
        }

        //Obtener las copias desde la Capa de Negocio y la vamos a enviar al DGV
        private void Mostrar()
        {
            try
            {
                copiaCN = new CopiaCN();
                DgvCopias.DataSource = copiaCN.Obtener();
                //DgvCopias.Columns["Id"].Visible = false;
                //DgvCopias.Columns["LibroId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Cargar los datos que vamos a necesitar en el formulario titulo libro
        private void CargarDatos()
        {
            try
            {
                CmbLibros.DataSource = libroCN.Obtener();
                CmbLibros.DisplayMember = "Titulo";
                CmbLibros.ValueMember = "Id";
                CmbLibros.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Limpiar los controles de texto
        private void LimpiarDatos()
        {
            TxtNoCopia.Text = "";
            CmbLibros.SelectedIndex = -1;

            TxtNoCopia.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Si es nuevo
                if (editar == false)
                {
                    if (CmbLibros.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar un libro de la lista disponible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    copia = new Copia(0, TxtNoCopia.Text, false, (int)CmbLibros.SelectedValue);

                    //copiaCN.ValidarAntesDeCrear(copia);

                    if (copiaCN.Insertar(copia))
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
                    copia = new Copia(copiaId, TxtNoCopia.Text,esPrestada, (int)CmbLibros.SelectedValue);

                    //copiaCN.ValidarAntesDeEditar(copia);

                    if (copiaCN.Editar(copia))
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
                if (DgvCopias.SelectedRows.Count > 0)
                {
                    editar = true;

                    TxtNoCopia.Text = "";
                    CmbLibros.SelectedIndex = -1;

                    TxtNoCopia.Text = DgvCopias.CurrentRow.Cells["NumeroCopia"].Value.ToString();
                    CmbLibros.SelectedValue = DgvCopias.CurrentRow.Cells["LibroId"].Value.ToString();
                    copiaId = int.Parse(DgvCopias.CurrentRow.Cells["Id"].Value.ToString());
                    esPrestada = bool.Parse(DgvCopias.CurrentRow.Cells["EsPrestada"].Value.ToString());
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
                if (DgvCopias.SelectedRows.Count > 0)
                {
                    copiaId = int.Parse(DgvCopias.CurrentRow.Cells["Id"].Value.ToString());

                    //copiaCN.ValidarAntesDeEliminar(copiaid);

                    if (copiaCN.Eliminar(copiaId))
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
