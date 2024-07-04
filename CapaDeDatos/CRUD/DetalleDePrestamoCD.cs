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
    public class DetalleDePrestamoCD
    {
        //Cadena de Conexion
        private ConexionCD Conexion = new ConexionCD();

        //Variables a Utilizar
        SqlDataReader LectorDatos;
        DataTable Tabla = new DataTable();
        SqlCommand Comando = new SqlCommand();


        public List<int> ObtenerCopiasPorPrestamoId(int prestamoId)
        {
            List<int> CopiasId = new List<int>();

            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ObtenerClientes";
            Comando.CommandType = CommandType.StoredProcedure;
            LectorDatos = Comando.ExecuteReader();

            while (LectorDatos.Read())
            {
                CopiasId.Add((int)LectorDatos["CopiaId"]);
            }

            return CopiasId;
        }


        public List<Cliente> ObtenerClientes(int prestamoId)
        {
            List<Cliente> clientes = new List<Cliente>();

            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ObtenerClientes";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@PrestamoId", prestamoId);
            LectorDatos = Comando.ExecuteReader();

            while (LectorDatos.Read())
            {
                clientes.Add(new Cliente
                {
                    Id = (int)LectorDatos["Id"],
                    Cedula = (string)LectorDatos["Cedula"],
                    Nombres = (string)LectorDatos["Nombres"],
                    Apellidos = (string)LectorDatos["Apellidos"]
                });
            }

            return clientes;
        }

        //Para insertar un registro en la tabla detalle de prestamo
        public bool InsertarDetallePrestamo(int prestamoId, int copiaId)
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

        //Para eliminar un registro en la tabla detalle de prestamo
        public bool EliminarDetallePrestamo(int prestamoId)
        {
            bool eliminado = false;

            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EliminarDetallesPrestamo";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@PrestamoId", prestamoId);
            eliminado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return eliminado;
        }



    }
}
