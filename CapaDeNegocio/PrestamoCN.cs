using CapaDeDatos.CRUD;
using Entidades;
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

        public DataTable Obtener(string codigo, int? clienteId)
        {
            DataTable Tabla = new DataTable();
            Tabla = prestamoCD.Obtener(codigo, clienteId);
            return Tabla;
        }

        public int? Insertar(Prestamo prestamo)
        {
            return prestamoCD.Insertar(prestamo);
        }

        public bool InsertarDetalle(int prestamoId, int copiaId)
        {
            return prestamoCD.InsertarDetalle(prestamoId,copiaId);
        }

        public bool Eliminar(int prestamoId)
        {
            return prestamoCD.Eliminar(prestamoId);
        }

        public bool EliminarDetallesPrestamo(int prestamoId)
        {
            return prestamoCD.EliminarDetallesPrestamo(prestamoId);
        }


    }
}
