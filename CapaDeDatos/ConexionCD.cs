using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    internal class ConexionCD
    {
        //Puede funcionar con .
        //Puede Funcionar con el nombre de la maquina DESKTOP-3RIGAIB\SQLEXPRESS
        //Cadena de conexion
        private SqlConnection Conexion = new SqlConnection("Data Source=.;Database=Biblioteca;Integrated Security=True");
        //private SqlConnection Conexion = new SqlConnection("Data Source=DESKTOP-3RIGAIB\\SQLEXPRESS;Database=Biblioteca;Integrated Security=True");

        //Metodo para abrir la conexion
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();

            return Conexion;
        }

        //Metodo cerrar la conexion

        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();

            return Conexion;
        }


    }
}
