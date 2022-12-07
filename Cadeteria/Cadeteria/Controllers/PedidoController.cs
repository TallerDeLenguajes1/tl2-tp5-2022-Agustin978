using Cadeteria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cadeteria.Controllers
{
    public class PedidoController : Controller
    {
        private static string path = @"C:\Cursos\Programacion_UNT\Taller_de_Lenguajes_2\tl2-tp5-2022-Agustin978\Cadeteria\Cadeteria\Archivos\pedidos";
        private static string ext = ".csv";
        private List<Models.PedidoModel> pedidos = new List<Models.PedidoModel>();
        
        public IActionResult Index()
        {
            helper help = new helper(path, ext);
            pedidos = help.pedidosAlmacenados();
            return View(pedidos);
        }

        public IActionResult IngresaPedido()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IngresaPedido(string observacion, string datosExtraDireccion, string estado, string nombre, string direccion, string telefono)
        {
            helper help = new helper(path, ext);
            List<PedidoModel> pedidosAlmacenados = help.pedidosAlmacenados();
            int ultimoPedido = 0;
            foreach(var pedido in pedidosAlmacenados)
            {
                ultimoPedido = pedido.getNroPedido();
            }
            help.agregaPedido(new PedidoModel(ultimoPedido + 1, observacion, datosExtraDireccion, nombre, direccion, telefono, estado));
            pedidos = help.pedidosAlmacenados();
            return View("Index", pedidos);
        }
    }
}
