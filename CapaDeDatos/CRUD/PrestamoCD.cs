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

        //public DataTable Obtener()
        //{
        //    Tabla = new DataTable();

        //    using (SqlConnection Conexion = ConexionCD.AbrirConexion())
        //    {
        //        using (SqlCommand Comando = new SqlCommand("ObtenerPrestamos", Conexion))
        //        {
        //            Comando.CommandType = CommandType.StoredProcedure;

        //            using (SqlDataReader lectorDatos = Comando.ExecuteReader())
        //            {
        //                Tabla.Load(lectorDatos);
        //            }

        //            ConexionCD.CerrarConexion();
        //        }
        //    }

        //    return Tabla;
        //}

        //Obtenemos todos los registros de la tabla Prestamo Filtrado 
        public DataTable Obtener(string codigo, int? clienteId)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ObtenerPrestamosFiltrados";
            Comando.Parameters.AddWithValue("@Codigo", codigo);
            Comando.Parameters.AddWithValue("@ClienteId", clienteId);
            Comando.CommandType = CommandType.StoredProcedure;
            LectorDatos = Comando.ExecuteReader();
            Tabla.Load(LectorDatos);
            Conexion.CerrarConexion();
            return Tabla;
        }

        //public DataTable Obtener(string codigo, int? clienteId)
        //{
        //    Tabla = new DataTable();

        //    using (SqlConnection conn = ConexionCD.AbrirConexion())
        //    {
        //        using (SqlCommand cmd = new SqlCommand("ObtenerPrestamosFiltrados", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Codigo", codigo);
        //            cmd.Parameters.AddWithValue("@ClienteId", clienteId);

        //            using (SqlDataReader lectorDatos = cmd.ExecuteReader())
        //            {
        //                Tabla.Load(lectorDatos);
        //            }

        //            ConexionCD.CerrarConexion();
        //        }
        //    }

        //    return Tabla;
        //}


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


        //public int? Insertar(Prestamo prestamo)
        //{
        //    int? idInsertado = null;

        //    using (SqlConnection conn = ConexionCD.AbrirConexion())
        //    {
        //        using (SqlCommand cmd = new SqlCommand("InsertarPrestamo", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Codigo", prestamo.Codigo);
        //            cmd.Parameters.AddWithValue("@FechaPrestamo", prestamo.FechaPrestamo);
        //            cmd.Parameters.AddWithValue("@FechaDevolucion", prestamo.FechaDevolucion);
        //            cmd.Parameters.AddWithValue("@ClienteId", prestamo.ClienteId);

        //            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int)
        //            {
        //                Direction = ParameterDirection.Output
        //            };

        //            cmd.Parameters.Add(outputIdParam);

        //            cmd.ExecuteNonQuery();

        //            ConexionCD.CerrarConexion();

        //            idInsertado = (int) outputIdParam.Value;
        //        }
        //    }

        //    return idInsertado;
        //}

        //Para insertar un registro en la tabla libro
        public bool InsertarDetalle(int prestamoId, int copiaId)
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

        //public bool InsertarDetalle(int prestamoId, int copiaId)
        //{
        //    bool agregado = false;

        //    using (SqlConnection conn = ConexionCD.AbrirConexion())
        //    {
        //        using (SqlCommand cmd = new SqlCommand("InsertarDetallePrestamo", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@PrestamoId", prestamoId);
        //            cmd.Parameters.AddWithValue("@CopiaId", copiaId);

        //            agregado = cmd.ExecuteNonQuery() > 0;

        //            ConexionCD.CerrarConexion();
        //        }
        //    } 

        //    return agregado;
        //}


        //Para eliminar un registro en la tabla prestamo
        public bool Eliminar(int prestamoId)
        {
            bool eliminado = false;

            Comando.CommandText = "EliminarPrestamo";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@PrestamoId", prestamoId);
            eliminado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return eliminado;
        }



        //public bool Eliminar(int prestamoId)
        //{
        //    bool eliminado = false;

        //    using (SqlConnection conn = ConexionCD.AbrirConexion())
        //    {
        //        using (SqlCommand cmd = new SqlCommand("EliminarPrestamo", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@PrestamoId", prestamoId);

        //            eliminado = cmd.ExecuteNonQuery() > 0;
        //            ConexionCD.CerrarConexion();

        //        }
        //    }

        //    return eliminado;
        //}

        //Para eliminar un registro en la tabla prestamo
        public bool EliminarDetallesPrestamo(int prestamoId)
        {
            bool eliminado = false;


            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@PrestamoId", prestamoId);
            eliminado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();


            return eliminado;

        }

        //public bool EliminarDetallesPrestamo(int prestamoId)
        //{
        //    bool eliminado = false;

        //    using (SqlConnection conn = ConexionCD.AbrirConexion())
        //    {
        //        using (SqlCommand cmd = new SqlCommand("EliminarDetallesPrestamo", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@PrestamoId", prestamoId);

        //            eliminado = cmd.ExecuteNonQuery() > 0;
        //            ConexionCD.CerrarConexion();
        //        }
        //    }

        //    return eliminado;
        //}





    }
}
