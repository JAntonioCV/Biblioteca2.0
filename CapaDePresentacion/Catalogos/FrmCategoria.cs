﻿using CapaDeNegocio;
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

namespace CapaDePresentacion.Catalogos
{
    public partial class FrmCategoria : Form
    {
        //Variables
        private CategoriaCN categoriaCN;
        private Categoria categoria;
        private bool editar = false;
        private int categoriaid;

        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            MostrarCategorias();
        }


        //Obtener las categorias desde la Capa de Negocio y la vamos a enviar al DGV
        private void MostrarCategorias()
        {
            categoriaCN = new CategoriaCN();
            DgvCategorias.DataSource = categoriaCN.ObtenerCategorias();
            DgvCategorias.Columns["Id"].Visible = false;
        }

        //Limpiar los controles de texto
        private void LimpiarDatos()
        {
            TxtCodigo.Text = "";
            TxtDescripcion.Text = "";
            TxtCodigo.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Si es nuevo
                if (editar == false)
                {
                    categoria = new Categoria(0, TxtCodigo.Text, TxtDescripcion.Text);
                    //categoria.Codigo = TxtCodigo.Text;
                    //categoria.Descripcion = TxtDescripcion.Text;

                    if (categoriaCN.Insertar(categoria))
                    {
                        LimpiarDatos();
                        MostrarCategorias();
                    }
                    else
                        MessageBox.Show("El registro no se inserto correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else //Es uno existente
                {
                    editar = false;
                    categoria = new Categoria(categoriaid, TxtCodigo.Text, TxtDescripcion.Text);

                    if (categoriaCN.Editar(categoria))
                    {
                        LimpiarDatos();
                        MostrarCategorias();
                    }
                    else
                        MessageBox.Show("El registro no se edito correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar o editar los datos por " + ex);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (DgvCategorias.SelectedRows.Count > 0)
            {
                editar = true;
                TxtCodigo.Text = DgvCategorias.CurrentRow.Cells["Codigo"].Value.ToString();
                TxtDescripcion.Text = DgvCategorias.CurrentRow.Cells["Descripcion"].Value.ToString();
                categoriaid = int.Parse(DgvCategorias.CurrentRow.Cells["Id"].Value.ToString());

            }
            else
                MessageBox.Show("Debe seleccionar una fila de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
