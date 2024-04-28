using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.CRUD
{
    internal class CategoriaCD
    {
        //Cadena de Conexion
        private ConexionCD Conexion = new ConexionCD();

        //Variables a Utilizar
        SqlDataReader LectorDatos;
        DataTable Tabla = new DataTable();
        SqlCommand Comando = new SqlCommand();

        //Obtenemos todos los registros de la tabla Categorias
        public DataTable ObtenerCategorias()
        {
            try
            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "SELECT * FROM Categorias";
                Comando.CommandType = CommandType.Text;
                LectorDatos = Comando.ExecuteReader();
                Conexion.CerrarConexion();
                Tabla.Load(LectorDatos);
            }
            catch (Exception ex)
            {
                string excepcion = ex.Message;
            }

            return Tabla;
        }

        public void Insertar(Categoria categoria)
        {
            try
            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "INSERT INTO Categorias (Codigo, Descripcion) VALUES (@codigo,@descripcion)";
                Comando.CommandType = CommandType.Text;
                Comando.Parameters.AddWithValue("@codigo", categoria.Codigo);
                Comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                Comando.ExecuteNonQuery();
                Comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            catch (Exception ex)
            {

                string msj = ex.ToString();
            }
        }



    }
}
