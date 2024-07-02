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
            Comando.CommandText = "ObtenerCopias";
            Comando.CommandType = CommandType.StoredProcedure;
            LectorDatos = Comando.ExecuteReader();
            Tabla.Load(LectorDatos);
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable Obtener(int libroId)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ObtenerCopiasPorLibro";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@LibroId", libroId);
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
            Comando.CommandText = "InsertarCopia";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@NumeroCopia", copia.NumeroCopia);
            Comando.Parameters.AddWithValue("@EsPrestada", copia.EsPrestada);
            Comando.Parameters.AddWithValue("@LibroId", copia.LibroId);
            agregado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return agregado;
        }

        //Para editar un registro en la tabla copia
        public bool Editar(Copia copia)
        {
            bool editado = false;

            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ActualizarCopia";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@NumeroCopia", copia.NumeroCopia);
            Comando.Parameters.AddWithValue("@EsPrestada", copia.EsPrestada);
            Comando.Parameters.AddWithValue("@LibroId", copia.LibroId);
            Comando.Parameters.AddWithValue("@Id", copia.Id);
            editado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return editado;
        }

        //Para eliminar un registro en la tabla copia
        public bool Eliminar(int copiaId)
        {
            bool eliminado = false;
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EliminarCopia";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Id", copiaId);
            eliminado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return eliminado;
        }

        public bool PrestarODevolverCopia(int copiaId, bool esPrestada)
        {
            bool editado = false;

            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "PrestarODevolverCopia";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Id", copiaId);
            Comando.Parameters.AddWithValue("@EsPrestada", esPrestada);
            editado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return editado;
        }


        //TODO: Validaciones que se deberian de hacer pero por tiempo las omito

        //Verificar si existe un registro con el numero de copia y libro

        //Verificar si existe otro registro con el numero de copia y libro pero con distinto Id

        //Verificar si existe un detalle de prestamo relacionada con la copia que queremos eliminar


    }
}
