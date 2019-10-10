using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using webApiT_Core.Entidades;

namespace webApiT_Core.Interfaces
{
    public interface ICore
    {
        List<Pedido> ObtenerProducto(int id);
        List<Pedido> ObtenerProducto();

        DataTable ObtenerProducto2();
        public string AgregarPedidos(Request request);
        bool testConection();
    }
}
