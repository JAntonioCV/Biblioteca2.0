using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
