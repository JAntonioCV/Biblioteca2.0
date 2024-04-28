using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public Categoria()
        {

        }

        public Categoria(int id, string codigo, string descripcion)
        {
            Id= id;
            Codigo= codigo;
            Descripcion= descripcion;
        }

    }
}
