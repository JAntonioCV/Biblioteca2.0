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
    public partial class FrmRptCategoria : Form
    {
        CategoriaCN categoriaCN = new CategoriaCN();
        public FrmRptCategoria()
        {
            InitializeComponent();
        }

        private void FrmRptCategoria_Load(object sender, EventArgs e)
        {
            bindingSource1.Clear();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource="CapaDePresentacion.Informes.RptCategoria.rdlc";
            bindingSource1.DataSource = categoriaCN.ObtenerCategorias();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet", bindingSource1));
            this.reportViewer1.RefreshReport();
        }
    }
}
