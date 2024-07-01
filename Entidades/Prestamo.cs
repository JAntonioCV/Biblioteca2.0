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

        public List<DetalleDePrestamo> DetallesDePrestamo { get; set; }

        public Prestamo()
        {
            DetallesDePrestamo = new List<DetalleDePrestamo>();
        }

        public Prestamo(int id, string codigo, DateTime fechaPrestamo, DateTime fechaDevolucion, int clienteId, List<DetalleDePrestamo> detallesDePrestamo)
        {
            Id = id;
            Codigo = codigo;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaDevolucion;
            ClienteId = clienteId;
            DetallesDePrestamo = detallesDePrestamo;

        }


    }
}
