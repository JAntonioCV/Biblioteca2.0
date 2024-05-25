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
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ObtenerCategorias";
            Comando.CommandType = CommandType.StoredProcedure;
            LectorDatos = Comando.ExecuteReader();
            Tabla.Load(LectorDatos);
            Conexion.CerrarConexion();

            return Tabla;
        }

        //Para insertar un registro en la tabla categoria
        public bool Insertar(Categoria categoria)
        {
            bool agregado = false;
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "InsertarCategoria";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", categoria.Codigo);
            Comando.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
            agregado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
            return agregado;

        }


        //Para editar un registro en la tabla categoria
        public bool Editar(Categoria categoria)
        {
            bool editado = false;

            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ActualizarCategoria";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Id", categoria.Id);
            Comando.Parameters.AddWithValue("@Codigo", categoria.Codigo);
            Comando.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
            editado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return editado;
        }

        //Para eliminar un registro en la tabla categoria
        public bool Eliminar(int categoriaId)
        {
            bool eliminado = false;
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EliminarCategoria";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Id", categoriaId);
            eliminado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return eliminado;
        }

        //Verificar si existe un registro con el codigo y la descripcion
        public bool ExisteCategoria(Categoria categoria)
        {
            bool existe = false;
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ExisteCategoria";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", categoria.Codigo);
            Comando.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
            existe = (int) Comando.ExecuteScalar() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return existe;
        }

        //Verificar si existe otro registro con el codigo y la descripcion pero con distinto Id
        public bool ExisteOtraCategoria(Categoria categoria)
        {
            bool existe = false;
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ExisteOtraCategoria";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@codigo", categoria.Codigo);
            Comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
            Comando.Parameters.AddWithValue("@Id", categoria.Id);
            existe = (int) Comando.ExecuteScalar() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return existe;
        }

        //Verificar si existe un libro relacionado con la categoria que queremos eliminar
        public bool CategoriaConLibros(int categoriaId)
        {
            bool existe = false;
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "CategoriaConLibros";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@CategoriaId", categoriaId);
            existe = (int) Comando.ExecuteScalar() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return existe;
        }





    }
}
