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

        //Editar la categoria a la Capa de datos
        public bool Editar(Categoria categoria)
        {
            return categoriaCD.Editar(categoria);
        }

        //Eliminar la categoria a la Capa de datos
        public bool Eliminar(int categoriaId)
        {
            return categoriaCD.Eliminar(categoriaId);
        }

        public void ValidarAntesDeCrear(Categoria categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.Codigo))
                throw new Exception("El campo Codigo no puede estar vacio o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(categoria.Descripcion))
                throw new Exception("El campo Descripcion no puede estar vacio o contener solo espacios en blanco");

            if (categoria.Codigo.Length > 3)
                throw new Exception("El campo Codigo no puede contener mas de 3 caracteres");

            if (categoria.Descripcion.Length > 100)
                throw new Exception("El campo Descripcion no puede contener mas de 100 caracteres");

            if (categoriaCD.ExisteCategoria(categoria))
                throw new Exception("Ya existe un registro con el codigo y la descripcion proporcionada");
        }

        public void ValidarAntesDeEditar(Categoria categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.Codigo))
                throw new Exception("El campo Codigo no puede estar vacio o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(categoria.Descripcion))
                throw new Exception("El campo Descripcion no puede estar vacio o contener solo espacios en blanco");

            if (categoria.Codigo.Length > 3)
                throw new Exception("El campo Codigo no puede contener mas de 3 caracteres");

            if (categoria.Descripcion.Length > 100)
                throw new Exception("El campo Descripcion no puede contener mas de 100 caracteres");

            if (categoriaCD.ExisteOtraCategoria(categoria))
                throw new Exception("Ya existe otro registro con el codigo y la descripcion proporcionada");
        }

        public void ValidarAntesDeEliminar(int categoriaId)
        {
            if (categoriaCD.CategoriaConLibros(categoriaId))
                throw new Exception("La cateogria a eliminar contiene libros relacionados");
        }


    }
}
