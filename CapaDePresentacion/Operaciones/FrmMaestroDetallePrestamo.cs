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
        private CopiaCN copia = new CopiaCN();

        public FrmMaestroDetallePrestamo()
        {
            InitializeComponent();
        }

        private void FrmMaestroDetallePrestamo_Load(object sender, EventArgs e)
        {
            DtpFechaEstimada.Enabled = false;
        }

        private void DtpFechaPrestamo_ValueChanged(object sender, EventArgs e)
        {
            DtpFechaEstimada.Value = DtpFechaPrestamo.Value.AddDays(4);
        }
    }
}
