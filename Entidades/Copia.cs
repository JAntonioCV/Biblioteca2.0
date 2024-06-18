using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Copia
    {
        public int Id { get; set; }
        public string NumeroCopia { get; set; }
        public bool EsPrestada { get; set; }
        public int LibroId { get; set; }

        public Copia()
        {

        }

        public Copia(int id, string numeroCopia, bool esPrestada, int libroId)
        {
            Id =id;
            NumeroCopia = numeroCopia;
            EsPrestada = esPrestada;
            LibroId = libroId;
        }
    }
}
