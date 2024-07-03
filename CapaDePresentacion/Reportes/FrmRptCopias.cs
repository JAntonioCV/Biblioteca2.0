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

namespace CapaDePresentacion.Reportes
{
    public partial class FrmRptCopias : Form
    {
        private CopiaCN copiaCN = new CopiaCN();
        public FrmRptCopias()
        {
            InitializeComponent();
        }

        private void FrmRptCopias_Load(object sender, EventArgs e)
        {
            bindingSource1.Clear();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "CapaDePresentacion.Informes.Report1.rdlc";
            bindingSource1.DataSource = copiaCN.Obtener();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", bindingSource1));
            this.reportViewer1.RefreshReport();
        }
    }
}
