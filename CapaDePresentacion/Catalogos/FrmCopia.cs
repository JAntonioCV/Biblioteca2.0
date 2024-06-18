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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaDePresentacion.Catalogos
{
    public partial class FrmCopia : Form
    {

        //Variables
        private CopiaCN copiaCN;
        private LibroCN libroCN = new LibroCN();
        private Copia copia;
        private bool editar = false;
        private int copiaId;

        public FrmCopia()
        {
            InitializeComponent();
        }

        private void FrmCopia_Load(object sender, EventArgs e)
        {
            Mostrar();
            CargarDatos();
        }

        //Obtener las copias desde la Capa de Negocio y la vamos a enviar al DGV
        private void Mostrar()
        {
            try
            {
                libroCN = new LibroCN();
                DgvCopias.DataSource = copiaCN.Obtener();
                DgvCopias.Columns["Id"].Visible = false;
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
                CmbLibros.DataSource = libroCN.Obtener();
                CmbLibros.DisplayMember = "Titulo";
                CmbLibros.ValueMember = "Id";
                CmbLibros.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
