using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleDePrestamo
    {
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public int CopiaId { get; set; }
        public string DescripcionLibro { get; set; }
        public string NumeroCopia { get; set; }

        public DetalleDePrestamo()
        {

        }

        public DetalleDePrestamo(int id, int prestamoId, int copiaId, string descripcionLibro, string numeroCopia)
        {
            Id = id;
            PrestamoId = prestamoId;
            CopiaId = copiaId;
            DescripcionLibro = descripcionLibro;
            NumeroCopia = numeroCopia;
        }

    }
}
