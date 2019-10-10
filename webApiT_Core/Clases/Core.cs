using System;
using System.Collections.Generic;
using System.Text;
using webApiT_Data.Interfaces;
using webApiT_Core.Entidades;
using System.Data;

namespace webApiT_Core.Clases
{
    public class Core:Interfaces.ICore    
    {
        private readonly IData _data;

        public Core(IData idata)
        {
            _data = idata;
        }

        public List<Pedido> ObtenerProducto(int id)
        {
            DataTable dt = _data.ObtenerPedidos(id);
            Pedido pd = new Pedido();
            List<Pedido> lpd = new List<Pedido>();

            foreach(DataRow row in dt.Rows)
            {
                pd.Tipo = row.ItemArray[3].ToString();
                pd.Cantidad = row.ItemArray[2].ToString();
                pd.Fecha = row.ItemArray[0].ToString();
                pd.Nombre = row.ItemArray[1].ToString();

                lpd.Add(pd);
            }

            return lpd;
        }

        public List<Pedido> ObtenerProducto()
        {
            DataTable dt = _data.ObtenerPedidos();
            
            List<Pedido> lpd = new List<Pedido>();

            foreach (DataRow row in dt.Rows)
            {
                Pedido pd = new Pedido();
                pd.Tipo = row.ItemArray[3].ToString();
                pd.Cantidad = row.ItemArray[2].ToString();
                pd.Fecha = row.ItemArray[0].ToString();
                pd.Nombre = row.ItemArray[1].ToString();
                lpd.Add(pd);

                pd = null;
            }
            return lpd;
        }

        public string AgregarPedidos(Request request)
        {
            return _data.AgregarPedidos(Convert.ToInt32(request.options), Convert.ToInt32(request.cantidad), Convert.ToInt32(request.inventarioId));
        }

        public bool testConection()
        {
            return _data.testConection();
        }

        public DataTable ObtenerProducto2()
        {
            DataTable dt = _data.ObtenerPedidos();

            return dt;
        }
    }
}
