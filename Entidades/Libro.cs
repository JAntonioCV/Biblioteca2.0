using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Titulo { get; set;}
        public string ISBN { get; set; }
        public string Autor { get; set; }
        public int CategoriaId { get; set; }

        public Libro()
        {
            
        }

        public Libro(int id, string codigo, string titulo, string isbn, string autor, int categoriaid)
        {
            Id = id;
            Codigo = codigo;
            Titulo = titulo;
            ISBN = isbn;
            Autor = autor;
            CategoriaId = categoriaid;
        }
    }
}
