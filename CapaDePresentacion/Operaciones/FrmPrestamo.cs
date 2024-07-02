using CapaDeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDePresentacion.Operaciones
{
    public partial class FrmPrestamo : Form
    {
        //Variables
        private PrestamoCN prestamoCN;
        private ClienteCN clienteCN = new ClienteCN();
        private int prestamoId; 

        public FrmPrestamo()
        {
            InitializeComponent();
        }

        private void FrmPrestamo_Load(object sender, EventArgs e)
        {
            Mostrar();
            CargarDatos();
        }

        //Obtener los prestamos desde la Capa de Negocio y la vamos a enviar al DGV
        private void Mostrar()
        {
            try
            {
                prestamoCN = new PrestamoCN();
                DgvPrestamos.DataSource = prestamoCN.Obtener();
                DgvPrestamos.Columns["Id"].Visible = false;
                DgvPrestamos.Columns["ClienteId"].Visible = false;
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
                CmbCliente.DataSource = clienteCN.ObtenerClientes();
                CmbCliente.DisplayMember = "NombreCompleto";
                CmbCliente.ValueMember = "Id";
                CmbCliente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            var frm = new Operaciones.FrmMaestroDetallePrestamo();
            frm.FormClosed += Frm_FormClosed;
            frm.ShowDialog();
            //frm.Dispose();
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Mostrar();
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = string.IsNullOrEmpty(TxtCodigo.Text) ? null : TxtCodigo.Text;
                int? clienteId = CmbCliente.SelectedValue != null ? (int?)CmbCliente.SelectedValue : null;

                prestamoCN = new PrestamoCN();
                DgvPrestamos.DataSource = prestamoCN.Obtener(codigo, clienteId);
                DgvPrestamos.Columns["Id"].Visible = false;
                DgvPrestamos.Columns["ClienteId"].Visible = false;
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
                if (DgvPrestamos.SelectedRows.Count > 0)
                {


                    //prestamoId = int.Parse(DgvPrestamos.CurrentRow.Cells["Id"].Value.ToString());

                    //categoriaCN.ValidarAntesDeEliminar(categoriaid);

                    //if (categoriaCN.Eliminar(categoriaid))
                    //{
                    //    LimpiarDatos();
                    //    MostrarCategorias();
                    //}
                    //else
                    //    MessageBox.Show("El registro no se elimino correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Debe seleccionar una fila de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            CmbCliente.SelectedIndex = -1;
            TxtCodigo.Text = string.Empty;
            Mostrar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvPrestamos.SelectedRows.Count > 0)
                {
                    prestamoId = int.Parse(DgvPrestamos.CurrentRow.Cells["Id"].Value.ToString());

                    var frm = new Operaciones.FrmMaestroDetallePrestamo();
                    frm.editar = true;
                    frm.prestamoId = prestamoId;
                    frm.FormClosed += Frm_FormClosed;
                    frm.ShowDialog();


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
