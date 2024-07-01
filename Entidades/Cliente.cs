using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public string NombreCompleto
        { 
            get { return Nombres + " " + Apellidos; } 
        }
    public Cliente()
        {
            
        }
        public Cliente(int id, string cedula, string nombres, string apellidos)
        {
            Id = id;
            Cedula = cedula;
            Nombres = nombres;
            Apellidos = apellidos;
        }
    }
}
