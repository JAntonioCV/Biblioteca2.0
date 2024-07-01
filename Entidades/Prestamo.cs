using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Prestamo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int ClienteId { get; set; }

        public List<DetalleDePrestamo> DetalleDePrestamos { get; set; }
    }
}
