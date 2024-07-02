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
    public class PrestamoCD
    {
        private ConexionCD Conexion = new ConexionCD();

        //Variables a Utilizar
        SqlDataReader LectorDatos;
        DataTable Tabla = new DataTable();
        SqlCommand Comando = new SqlCommand();

        //Obtenemos todos los registros de la tabla Prestamo
        public DataTable Obtener()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ObtenerPrestamos";
            Comando.CommandType = CommandType.StoredProcedure;
            LectorDatos = Comando.ExecuteReader();
            Tabla.Load(LectorDatos);
            Conexion.CerrarConexion();
            return Tabla;
        }

        //Obtenemos todos los registros de la tabla Prestamo Filtrado 
        public DataTable Obtener(string codigo, int? clienteId)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ObtenerPrestamosFiltrados";
            Comando.Parameters.AddWithValue("@Codigo",codigo);
            Comando.Parameters.AddWithValue("@ClienteId", clienteId);
            Comando.CommandType = CommandType.StoredProcedure;
            LectorDatos = Comando.ExecuteReader();
            Tabla.Load(LectorDatos);
            Conexion.CerrarConexion();
            return Tabla;
        }

        //Para insertar un registro en la tabla libro
        public int? Insertar(Prestamo prestamo)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "InsertarPrestamo";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", prestamo.Codigo);
            Comando.Parameters.AddWithValue("@FechaPrestamo", prestamo.FechaPrestamo);
            Comando.Parameters.AddWithValue("@FechaDevolucion", prestamo.FechaDevolucion);
            Comando.Parameters.AddWithValue("@ClienteId", prestamo.ClienteId);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            Comando.Parameters.Add(outputIdParam);

            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return (int)outputIdParam.Value;
        }

        //Para insertar un registro en la tabla libro
        public bool InsertarDetalle(int prestamoId, int copiaId )
        {
            bool agregado = false;
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "InsertarDetallePrestamo";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@PrestamoId", prestamoId);
            Comando.Parameters.AddWithValue("@CopiaId", copiaId);

            agregado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return agregado;
        }


    }
}
