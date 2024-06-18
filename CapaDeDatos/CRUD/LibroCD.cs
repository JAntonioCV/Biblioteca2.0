using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace CapaDeDatos.CRUD
{
    public class LibroCD
    {
        private ConexionCD Conexion = new ConexionCD();

        //Variables a Utilizar
        SqlDataReader LectorDatos;
        DataTable Tabla = new DataTable();
        SqlCommand Comando = new SqlCommand();

        //Obtenemos todos los registros de la tabla libro
        public DataTable Obtener()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ObtenerLibros";
            Comando.CommandType = CommandType.StoredProcedure;
            LectorDatos = Comando.ExecuteReader();
            Tabla.Load(LectorDatos);
            Conexion.CerrarConexion();
            return Tabla;
        }

        //Para insertar un registro en la tabla libro
        public bool Insertar(Libro libro)
        {
            bool agregado = false;
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "InsertarLibro";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", libro.Codigo);
            Comando.Parameters.AddWithValue("@Titulo", libro.Titulo);
            Comando.Parameters.AddWithValue("@ISBN", libro.ISBN);
            Comando.Parameters.AddWithValue("@Autor", libro.Autor);
            Comando.Parameters.AddWithValue("@CategoriaId", libro.CategoriaId);
            agregado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return agregado;
        }

        //Para editar un registro en la tabla libro
        public bool Editar(Libro libro)
        {
            bool editado = false;

            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ActualizarLibro";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", libro.Codigo);
            Comando.Parameters.AddWithValue("@Titulo", libro.Titulo);
            Comando.Parameters.AddWithValue("@ISBN", libro.ISBN);
            Comando.Parameters.AddWithValue("@Autor", libro.Autor);
            Comando.Parameters.AddWithValue("@CategoriaId", libro.CategoriaId);
            Comando.Parameters.AddWithValue("@Id", libro.Id);
            editado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return editado;
        }

        //Para eliminar un registro en la tabla libro
        public bool Eliminar(int categoriaId)
        {
            bool eliminado = false;
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EliminarLibro";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Id", categoriaId);
            eliminado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return eliminado;

        }

        //TODO: Validaciones que se deberian de hacer pero por tiempo las omito

        //Verificar si existe un registro con el codigo, titulo e ISBN 

        //Verificar si existe otro registro con el codigo, titulo e ISBN pero con distinto Id

        //Verificar si existe una copia relacionada con el libro que queremos eliminar
    }
}
