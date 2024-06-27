using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class Cliente
    {
        public string NombreCompleto
        { get { return Nombres + " " + Apellidos; } }
    }
}
