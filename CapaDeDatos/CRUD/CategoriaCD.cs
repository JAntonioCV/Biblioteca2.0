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
    public class CategoriaCD
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
                Tabla.Load(LectorDatos);
                Conexion.CerrarConexion();
                
            }
            catch (Exception ex)
            {
                string excepcion = ex.Message;
            }

            return Tabla;
        }

        //Para insertar un registro en la tabla categoria
        public bool Insertar(Categoria categoria)
        {
            bool agregado = false;
            try
            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "INSERT INTO Categorias (Codigo, Descripcion) VALUES (@codigo,@descripcion)";
                Comando.CommandType = CommandType.Text;
                Comando.Parameters.AddWithValue("@codigo", categoria.Codigo);
                Comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);

                agregado = Comando.ExecuteNonQuery() > 0;
                Comando.Parameters.Clear();
                Conexion.CerrarConexion();
                return agregado;
            }

            catch (Exception ex)
            {
                string msj = ex.ToString();
                return false;
            }
        }

        //Para editar un registro en la tabla categoria
        public bool Editar(Categoria categoria)
        {
            bool editado = false;
            try
            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "UPDATE Categorias SET Codigo = @codigo, Descripcion = @descripcion WHERE Id = @Id";
                Comando.CommandType = CommandType.Text;
                Comando.Parameters.AddWithValue("@codigo", categoria.Codigo);
                Comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                Comando.Parameters.AddWithValue("@Id", categoria.Id);
                editado = Comando.ExecuteNonQuery() > 0;
                Comando.Parameters.Clear();
                Conexion.CerrarConexion();

                return editado;
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                return false;
            }
        }

        //Para eliminar un registro en la tabla categoria
        public bool Eliminar(int categoriaId) 
        {
            bool eliminado = false;
            try
            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "DELETE FROM Categorias WHERE Id = @Id";
                Comando.Parameters.AddWithValue("@Id", categoriaId);
                eliminado = Comando.ExecuteNonQuery() > 0;
                Comando.Parameters.Clear();
                Conexion.CerrarConexion();

                return eliminado;
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                return false;
            }
        }

        //Verificar si existe una tabla con el codigo y la descripcion
        public bool VerificarRegistros(Categoria categoria) 
        {
            bool existe = false;

            try
            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "SELECT COUNT(*) FROM Categorias WHERE Codigo = @Codigo AND Descripcion = @descripcion";
                Comando.Parameters.AddWithValue("@codigo", categoria.Codigo);
                Comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                existe = (int) Comando.ExecuteScalar() > 0;
                Comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                string msj = ex.Message;
            }

            return existe;
        }





    }
}
