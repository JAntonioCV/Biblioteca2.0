using CapaDeDatos.CRUD;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio
{
    public class ClienteCN
    {
        private ClienteCD clienteCD = new ClienteCD();

        //Obtener los clientes desde la Capa de datos
        public DataTable Obtener()
        {
            DataTable Tabla = new DataTable();
            Tabla = clienteCD.Obtener();
            return Tabla;
        }

        //Agregar el Cliente a la Capa de datos
        public bool Insertar(Cliente cliente)
        {
            return clienteCD.Insertar(cliente);
        }

        //Editar el Cliente a la Capa de datos
        public bool Editar(Cliente cliente)
        {
            return clienteCD.Editar(cliente);
        }

        //Eliminar el Cliente a la Capa de datos
        public bool Eliminar(int clienteId)
        {
            return clienteCD.Eliminar(clienteId);
        }
    }
}
