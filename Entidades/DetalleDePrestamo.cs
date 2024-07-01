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
    }
}
