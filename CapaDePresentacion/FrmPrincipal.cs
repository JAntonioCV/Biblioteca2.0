using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDePresentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void categoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new Catalogos.FrmCategoria();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void libroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Catalogos.FrmLibro();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void copiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Catalogos.FrmCopia();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Reportes.FrmRptCategoria();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var frm = new Reportes.FrmRptCategoria();
            //frm.ShowDialog();
            //frm.Dispose();
        }

        private void prestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Operaciones.FrmPrestamo();
            frm.ShowDialog();
            frm.Dispose();
        }
    }
}
