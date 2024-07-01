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

namespace CapaDePresentacion.Operaciones
{
    public partial class FrmMaestroDetallePrestamo : Form
    {
        private ClienteCN clienteCN = new ClienteCN();
        private LibroCN libroCN = new LibroCN();
        private CopiaCN copiaCN;
        private Prestamo prestamo = new Prestamo();
        private DetalleDePrestamo detalleDePrestamo;
        private BindingList<DetalleDePrestamo> detallesDePrestamo = new BindingList<DetalleDePrestamo>();
        //private List<DetalleDePrestamo> detallesDePrestamo = new List<DetalleDePrestamo>();

        private bool isInitializing = true;

        public FrmMaestroDetallePrestamo()
        {
            InitializeComponent();
        }

        private void FrmMaestroDetallePrestamo_Load(object sender, EventArgs e)
        {
            DgvPrestamos.DataSource = detallesDePrestamo;
            CargarDatos();
            DtpFechaEstimada.Value = DtpFechaPrestamo.Value.AddDays(4);
            
        }

        private void DtpFechaPrestamo_ValueChanged(object sender, EventArgs e)
        {
            DtpFechaEstimada.Value = DtpFechaPrestamo.Value.AddDays(4);
        }

        private void CargarDatos()
        {
            try
            {
                CmbCliente.DataSource = clienteCN.ObtenerClientes();
                CmbCliente.DisplayMember = "NombreCompleto";
                CmbCliente.ValueMember = "Id";
                CmbCliente.SelectedIndex = -1;

                isInitializing = true;
                CmbLibros.DataSource = libroCN.Obtener();
                CmbLibros.DisplayMember = "Titulo";
                CmbLibros.ValueMember = "Id";
                CmbLibros.SelectedIndex = -1;

                isInitializing = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CmbLibros_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (isInitializing) return;

                if (CmbLibros.SelectedIndex != -1)
                {
                    copiaCN = new CopiaCN();
                    int libroId = (int)CmbLibros.SelectedValue;
                    CmbCopia.DataSource = copiaCN.Obtener(libroId);
                    CmbCopia.DisplayMember = "NumeroCopia";
                    CmbCopia.ValueMember = "Id";
                    CmbCopia.SelectedIndex = -1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (CmbLibros.SelectedIndex != -1 && CmbCopia.SelectedIndex != -1)
            {
                var nombre = CmbLibros.GetItemText(CmbLibros.SelectedItem); 
                detalleDePrestamo = new DetalleDePrestamo(0, 0, (int)CmbCopia.SelectedValue,nombre);
                detallesDePrestamo.Add(detalleDePrestamo);
            }
            else 
            {
                MessageBox.Show("Debe seleccionar un libro o una copia de las listas disponible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
