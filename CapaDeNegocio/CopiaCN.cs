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
    public class CopiaCN
    {
        private CopiaCD copiaCD = new CopiaCD();

        //Obtener los Copias desde la Capa de datos
        public DataTable Obtener()
        {
            DataTable Tabla = new DataTable();
            Tabla = copiaCD.Obtener();
            return Tabla;
        }

        //Obtener las copias de un libro proporcionado
        public DataTable Obtener(int libroId) 
        {
            return copiaCD.Obtener(libroId);
        }

        //Agregar el Copia a la Capa de datos
        public bool Insertar(Copia copia)
        {
            return copiaCD.Insertar(copia);
        }

        //Editar el Copia a la Capa de datos
        public bool Editar(Copia copia)
        {
            return copiaCD.Editar(copia);
        }

        //Eliminar el Copia a la Capa de datos
        public bool Eliminar(int copiaId)
        {
            return copiaCD.Eliminar(copiaId);
        }
    }
}
