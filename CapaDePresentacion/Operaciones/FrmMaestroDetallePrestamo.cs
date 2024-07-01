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
    public partial class FrmMaestroDetallePrestamo : Form
    {
        private ClienteCN clienteCN = new ClienteCN();
        private LibroCN libroCN = new LibroCN();
        private CopiaCN copiaCN;
        private bool isInitializing = true;

        public FrmMaestroDetallePrestamo()
        {
            InitializeComponent();
        }

        private void FrmMaestroDetallePrestamo_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void DtpFechaPrestamo_ValueChanged(object sender, EventArgs e)
        {
            DtpFechaEstimada.Value = DtpFechaPrestamo.Value.AddDays(4);
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
    }
}
