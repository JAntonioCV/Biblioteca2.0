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
    public class ClienteCD
    {
        //Cadena de Conexion
        private ConexionCD Conexion = new ConexionCD();

        //Variables a Utilizar
        SqlDataReader LectorDatos;
        DataTable Tabla = new DataTable();
        SqlCommand Comando = new SqlCommand();

        //Obtenemos todos los registros de la tabla Clientes
        public DataTable Obtener()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ObtenerClientes";
            Comando.CommandType = CommandType.StoredProcedure;
            LectorDatos = Comando.ExecuteReader();
            Tabla.Load(LectorDatos);
            Conexion.CerrarConexion();

            return Tabla;
        }

        public List<Cliente> ObtenerClientes() 
        {
            List<Cliente> clientes = new List<Cliente>();

            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ObtenerClientes";
            Comando.CommandType = CommandType.StoredProcedure;

            LectorDatos = Comando.ExecuteReader();

            while (LectorDatos.Read())
            {
                clientes.Add(new Cliente
                {
                    Id = (int) LectorDatos["Id"],
                    Cedula = (string) LectorDatos["Cedula"],
                    Nombres = (string) LectorDatos["Nombres"],
                    Apellidos = (string)LectorDatos["Apellidos"]
                });
            }

            return clientes;
        }
           


        //Para insertar un registro en la tabla cliente
        public bool Insertar(Cliente cliente)
        {
            bool agregado = false;
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "InsertarCliente";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Cedula", cliente.Cedula);
            Comando.Parameters.AddWithValue("@Nombres", cliente.Nombres);
            Comando.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
            agregado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return agregado;
        }

        //Para editar un registro en la tabla cliente
        public bool Editar(Cliente cliente)
        {
            bool editado = false;

            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ActualizarCliente";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Cedula", cliente.Cedula);
            Comando.Parameters.AddWithValue("@Nombres", cliente.Nombres);
            Comando.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
            Comando.Parameters.AddWithValue("@Id", cliente.Id);
            editado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return editado;
        }

        //Para eliminar un registro en la tabla cliente
        public bool Eliminar(int clienteId)
        {
            bool eliminado = false;
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EliminarCliente";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Id", clienteId);
            eliminado = Comando.ExecuteNonQuery() > 0;
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

            return eliminado;
        }




    }
}
