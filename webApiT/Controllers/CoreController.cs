using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webApiT_Core.Entidades;
using webApiT_Core.Interfaces;

namespace webApiT.Controllers
{
    [Route("api/core")]
    [ApiController]
    public class CoreController : Controller
    {
        // GET api/values

        ICore _icore;
        public CoreController(ICore icore)
        {
            _icore = icore;
        }        
        [HttpGet]
        public ActionResult<List<Pedido>> Get()
        {
            return _icore.ObtenerProducto();
        }

        //public ActionResult<DataTable> Get()
        //{
        //    return _icore.ObtenerProducto2();
        //}

        [HttpGet("{id}")]
        public ActionResult<List<Pedido>> Get(int id)
        {
            return _icore.ObtenerProducto(id);
        }

        [HttpPost]
        public string Post(Request request)
        {
            return _icore.AgregarPedidos(request);
        }
        //public ActionResult<bool> Get()
        //{
        //    return _icore.testConection();
        //}
    }
}