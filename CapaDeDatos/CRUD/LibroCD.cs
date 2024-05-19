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
            Comando.CommandText = "SELECT * FROM Libros";
            Comando.CommandType = CommandType.Text;
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
            Comando.CommandText = "INSERT INTO Libros (Codigo, Titulo, ISBN, Autor, CategoriaId) VALUES (@codigo, @titulo, @isbn, @autor, @categoriaId)";
            Comando.CommandType = CommandType.Text;
            Comando.Parameters.AddWithValue("@codigo", libro.Codigo);
            Comando.Parameters.AddWithValue("@titulo", libro.Titulo);
            Comando.Parameters.AddWithValue("@isbn", libro.ISBN);
            Comando.Parameters.AddWithValue("@autor", libro.Autor);
            Comando.Parameters.AddWithValue("@categoriaId", libro.CategoriaId);
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
            Comando.CommandText = "UPDATE Libros SET Codigo = @codigo, Titulo = @titulo, ISBN = @isbn, Autor = @autor, CategoriaId = @categoriaId WHERE Id = @Id";
            Comando.CommandType = CommandType.Text;
            Comando.Parameters.AddWithValue("@codigo", libro.Codigo);
            Comando.Parameters.AddWithValue("@titulo", libro.Titulo);
            Comando.Parameters.AddWithValue("@isbn", libro.ISBN);
            Comando.Parameters.AddWithValue("@autor", libro.Autor);
            Comando.Parameters.AddWithValue("@categoriaId", libro.CategoriaId);
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
            Comando.CommandText = "DELETE FROM Libros WHERE Id = @Id";
            Comando.Parameters.AddWithValue("@Id", categoriaId);
            eliminado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return eliminado;

        }

        //Se esta Trabajando XD

        ////Verificar si existe un registro con el codigo y la descripcion
        //public bool ExisteLibro(Categoria categoria)
        //{
        //    bool existe = false;

        //    try
        //    {
        //        Comando.Connection = Conexion.AbrirConexion();
        //        Comando.CommandText = "SELECT COUNT(*) FROM Categorias WHERE Codigo = @Codigo AND Descripcion = @descripcion";
        //        Comando.Parameters.AddWithValue("@codigo", categoria.Codigo);
        //        Comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);

        //        existe = (int)Comando.ExecuteScalar() > 0;
        //        Comando.Parameters.Clear();
        //        Conexion.CerrarConexion();
        //    }
        //    catch (Exception ex)
        //    {
        //        string msj = ex.Message;
        //    }

        //    return existe;
        //}

        ////Verificar si existe otro registro con el codigo y la descripcion pero con distinto Id
        //public bool ExisteOtroLibro(Categoria categoria)
        //{
        //    bool existe = false;

        //    try
        //    {
        //        Comando.Connection = Conexion.AbrirConexion();
        //        Comando.CommandText = "SELECT COUNT(*) FROM Categorias where Codigo = @Codigo AND Descripcion = @descripcion AND Id != @Id";
        //        Comando.Parameters.AddWithValue("@codigo", categoria.Codigo);
        //        Comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
        //        Comando.Parameters.AddWithValue("@Id", categoria.Id);
        //        existe = (int)Comando.ExecuteScalar() > 0;
        //        Comando.Parameters.Clear();
        //        Conexion.CerrarConexion();
        //    }
        //    catch (Exception ex)
        //    {
        //        string msj = ex.Message;
        //    }

        //    return existe;
        //}

        ////Verificar si existe un libro relacionado con la categoria que queremos eliminar
        //public bool CategoriaConLibros(int categoriaId)
        //{
        //    bool existe = false;

        //    Comando.Connection = Conexion.AbrirConexion();
        //    Comando.CommandText = "SELECT COUNT(*) FROM Libros where CategoriaId = @categoriaId";
        //    Comando.Parameters.AddWithValue("@categoriaId", categoriaId);
        //    existe = (int)Comando.ExecuteScalar() > 0;
        //    Comando.Parameters.Clear();
        //    Conexion.CerrarConexion();

        //    return existe;
        //}

    }
}
