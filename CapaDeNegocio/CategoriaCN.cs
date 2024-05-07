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
    public class CategoriaCN
    {
        private CategoriaCD categoriaCD  = new CategoriaCD();

        //Obtener las cateogrias desde la Capa de datos
        public DataTable ObtenerCategorias() 
        {
            DataTable Tabla  = new DataTable();
            Tabla = categoriaCD.ObtenerCategorias();
            return Tabla;
        }

        //Agregar la categoria a la Capa de datos
        public bool Insertar(Categoria categoria)
        {
            return categoriaCD.Insertar(categoria);
        }

        //Editar la categoria a la Capa de datosRTE
        public bool Editar(Categoria categoria)
        {
            categoria.Codigo.Length > 3 

            return categoriaCD.Editar(categoria);
        }

        //Eliminar la categoria a la Capa de datos
        public bool Eliminar(int categoriaId)
        {
            return categoriaCD.Eliminar(categoriaId);
        }




    }
}
