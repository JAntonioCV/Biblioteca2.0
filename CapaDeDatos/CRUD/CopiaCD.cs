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
    public class CopiaCD
    {
        //Cadena de Conexion
        private ConexionCD Conexion = new ConexionCD();

        //Variables a Utilizar
        SqlDataReader LectorDatos;
        DataTable Tabla = new DataTable();
        SqlCommand Comando = new SqlCommand();

        //Obtenemos todos los registros de la tabla copia
        public DataTable Obtener()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "SELECT L.Titulo ,C.NumeroCopia FROM Copias C INNER JOIN Libros L on C.LibroId = L.Id";
            Comando.CommandType = CommandType.Text;
            LectorDatos = Comando.ExecuteReader();
            Tabla.Load(LectorDatos);
            Conexion.CerrarConexion();
            return Tabla;
        }

        //Para insertar un registro en la tabla copia
        public bool Insertar(Copia copia)
        {
            bool agregado = false;
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "INSERT INTO Copias (NumeroCopia, Prestada, LibroId) VALUES (@numeroCopia, @prestada, @libroId)";
            Comando.CommandType = CommandType.Text;
            Comando.Parameters.AddWithValue("@numeroCopia", copia.NumeroCopia);
            Comando.Parameters.AddWithValue("@prestada", copia.Prestada);
            Comando.Parameters.AddWithValue("@libroId", copia.LibroId);
            agregado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return agregado;
        }

        //Para editar un registro en la tabla copia
        //public bool Editar(Copia copia)
        //{
        //    bool editado = false;

        //    Comando.Connection = Conexion.AbrirConexion();
        //    Comando.CommandText = "UPDATE Libros SET Codigo = @codigo, Titulo = @titulo, ISBN = @isbn, Autor = @autor, CategoriaId = @categoriaId WHERE Id = @Id";
        //    Comando.CommandType = CommandType.Text;
        //    Comando.Parameters.AddWithValue("@codigo", libro.Codigo);
        //    Comando.Parameters.AddWithValue("@titulo", libro.Titulo);
        //    Comando.Parameters.AddWithValue("@isbn", libro.ISBN);
        //    Comando.Parameters.AddWithValue("@autor", libro.Autor);
        //    Comando.Parameters.AddWithValue("@categoriaId", libro.CategoriaId);
        //    Comando.Parameters.AddWithValue("@Id", libro.Id);
        //    editado = Comando.ExecuteNonQuery() > 0;
        //    Comando.Parameters.Clear();
        //    Conexion.CerrarConexion();

        //    return editado;
        //}


    }
}
