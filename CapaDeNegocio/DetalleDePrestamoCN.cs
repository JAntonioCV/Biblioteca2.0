using CapaDeDatos.CRUD;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio
{
    public class DetalleDePrestamoCN
    {
        private DetalleDePrestamoCD detalleDePrestamoCD = new DetalleDePrestamoCD();


        public List<int> ObtenerCopiasPorPrestamoId(int prestamoId) 
        {
            return detalleDePrestamoCD.ObtenerCopiasPorPrestamoId(prestamoId);
        }

        public bool InsertarDetallePrestamo(int prestamoId, int copiaId)
        {
            return detalleDePrestamoCD.InsertarDetallePrestamo(prestamoId, copiaId);
        }

        public bool EliminarDetallePrestamo(int prestamoId)
        {
            return detalleDePrestamoCD.EliminarDetallePrestamo(prestamoId);
        }

    }
}
