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
    public class LibroCN
    {
        private LibroCD libroCD = new LibroCD();

        //Obtener los libros desde la Capa de datos
        public DataTable Obtener()
        {
            DataTable Tabla = new DataTable();
            Tabla = libroCD.Obtener();
            return Tabla;
        }

        //Agregar el Libro a la Capa de datos
        public bool Insertar(Libro libro)
        {
            return libroCD.Insertar(libro);
        }

        //Editar el Libro a la Capa de datos
        public bool Editar(Libro libro)
        {
            return libroCD.Editar(libro);
        }

        //Eliminar el Libro a la Capa de datos
        public bool Eliminar(int libroId)
        {
            return libroCD.Eliminar(libroId);
        }
    }
}
