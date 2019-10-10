using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace webApiT_Data.Interfaces
{
    public interface IData
    {
        DataTable ObtenerPedidos(int id);
        DataTable ObtenerPedidos();
        string AgregarPedidos(int options, int cantidad, int inventarioId);
        bool testConection();
    }
}
