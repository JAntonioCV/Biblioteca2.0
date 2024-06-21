using CapaDeDatos.CRUD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio
{
    public class PrestamoCN
    {
        private PrestamoCD prestamoCD = new PrestamoCD();

        //Obtener los prestamos desde la Capa de datos
        public DataTable Obtener()
        {
            DataTable Tabla = new DataTable();
            Tabla = prestamoCD.Obtener();
            return Tabla;
        }
    }
}
