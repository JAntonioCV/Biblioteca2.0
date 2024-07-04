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
        private PrestamoCN prestamoCN;
        private CopiaCN copiaCN;
        private Prestamo prestamo = new Prestamo();
        private DetalleDePrestamo detalleDePrestamo;
        private DetalleDePrestamoCN detalleDePrestamoCN = new DetalleDePrestamoCN();
        private BindingList<DetalleDePrestamo> detallesDePrestamoBindingList = new BindingList<DetalleDePrestamo>();
        public bool editar=false;
        public int prestamoId;
        //private List<DetalleDePrestamo> detallesDePrestamo = new List<DetalleDePrestamo>();

        private bool isInitializing = true;

        public FrmMaestroDetallePrestamo()
        {
            InitializeComponent();
        }

        private void FrmMaestroDetallePrestamo_Load(object sender, EventArgs e)
        {
            prestamoCN = new PrestamoCN();

            DgvPrestamos.DataSource = detallesDePrestamoBindingList;
            DgvPrestamos.Columns["Id"].Visible = false;
            DgvPrestamos.Columns["PrestamoId"].Visible = false;
            DgvPrestamos.Columns["CopiaId"].Visible = false;
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
                var nombreLibro = CmbLibros.GetItemText(CmbLibros.SelectedItem);
                var numeroCopia = CmbCopia.GetItemText(CmbCopia.SelectedItem);

                detalleDePrestamo = new DetalleDePrestamo(0, 0, (int)CmbCopia.SelectedValue, nombreLibro,numeroCopia);
                detallesDePrestamoBindingList.Add(detalleDePrestamo);

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
            try
            {
                if (editar == false)
                {
                    copiaCN = new CopiaCN();

                    prestamo = new Prestamo(0,TxtCodigo.Text,DtpFechaPrestamo.Value, new DateTime(1900, 1, 1),(int) CmbCliente.SelectedValue);

                    int? prestamoId = prestamoCN.Insertar(prestamo);

                    if (prestamoId != null) 
                    {
                        foreach (var detalle in detallesDePrestamoBindingList)
                        {
                            if (detalleDePrestamoCN.InsertarDetallePrestamo(prestamoId.Value, detalle.CopiaId))
                                copiaCN.PrestarODevolverCopia(detalle.CopiaId, true);
                        }

                        this.Close();
                    }
                }
                else 
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
