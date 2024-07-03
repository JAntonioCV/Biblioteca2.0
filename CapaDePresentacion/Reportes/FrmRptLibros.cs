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
    public partial class FrmRptLibros : Form
    {
        private LibroCN libroCN = new LibroCN();
        public FrmRptLibros()
        {
            InitializeComponent();
        }

        private void FrmRptLibros_Load(object sender, EventArgs e)
        {
            bindingSource1.Clear();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "CapaDePresentacion.Informes.Report2.rdlc";
            bindingSource1.DataSource = libroCN.Obtener();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", bindingSource1));
            this.reportViewer1.RefreshReport();
        }
    }
}
