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
    public partial class FrmClientes : Form
    {
        //Variables
        private ClienteCN clienteCN;
        private Cliente cliente;
        private bool editar = false;
        private int clienteId;


        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        //Obtener las copias desde la Capa de Negocio y la vamos a enviar al DGV
        private void Mostrar()
        {
            try
            {
                clienteCN = new ClienteCN();
                DgvClientes.DataSource = clienteCN.Obtener();
                DgvClientes.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Limpiar los controles de texto
        private void LimpiarDatos()
        {
            TxtCedula.Text = "";
            TxtNombres.Text = "";
            TxtApellidos.Text = "";
            TxtCedula.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Si es nuevo
                if (editar == false)
                {
                    cliente = new Cliente(0,TxtCedula.Text, TxtNombres.Text,TxtApellidos.Text);

                    //copiaCN.ValidarAntesDeCrear(copia);

                    if (clienteCN.Insertar(cliente))
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
                    cliente = new Cliente(clienteId, TxtCedula.Text, TxtNombres.Text, TxtApellidos.Text);

                    //copiaCN.ValidarAntesDeEditar(copia);

                    if (clienteCN.Editar(cliente))
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
                if (DgvClientes.SelectedRows.Count > 0)
                {
                    editar = true;

                    TxtCedula.Text = "";
                    TxtNombres.Text = "";
                    TxtApellidos.Text = "";

                    TxtCedula.Text = DgvClientes.CurrentRow.Cells["Cedula"].Value.ToString();
                    TxtNombres.Text = DgvClientes.CurrentRow.Cells["Nombres"].Value.ToString();
                    TxtApellidos.Text = DgvClientes.CurrentRow.Cells["Apellidos"].Value.ToString();

                    clienteId = int.Parse(DgvClientes.CurrentRow.Cells["Id"].Value.ToString());
                
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
                if (DgvClientes.SelectedRows.Count > 0)
                {
                    clienteId = int.Parse(DgvClientes.CurrentRow.Cells["Id"].Value.ToString());

                    //copiaCN.ValidarAntesDeEliminar(copiaid);

                    if (clienteCN.Eliminar(clienteId))
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
