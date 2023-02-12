using AutoMapper;
using Cadeteria.Models;
using Cadeteria.ViewModels.Pedido;
using Cadeteria.ViewModels.Cadete;
using Microsoft.AspNetCore.Mvc;
using Cadeteria.Repositorio;

namespace Cadeteria.Controllers
{
    public class PedidoController : Controller
    {
        private static string path = @"C:\Cursos\Programacion_UNT\Taller_de_Lenguajes_2\tl2-tp5-2022-Agustin978\Cadeteria\Cadeteria\Archivos\pedidos";
        private static string ext = ".csv";
        //private List<Models.PedidoModel> pedidos = new List<Models.PedidoModel>();
        private readonly ILogger<PedidoController> _logger;
        private readonly IRepositorio<PedidoModel> _repo;
        private readonly IRepositorio<CadeteModel> _repoCad;
        private readonly IMapper _mapper;

        public PedidoController(ILogger<PedidoController> logger, IRepositorio<PedidoModel> repo, IRepositorio<CadeteModel> repoCad, IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _repoCad = repoCad;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //helper help = new helper(path, ext);
            //var pedidos = help.pedidosAlmacenados();
            List<PedidoModel> pedidos = _repo.listarTodos();
            //Mapeo de los datos obtenidos de la base de datos
            var pedidosViewModel = _mapper.Map<List<PedidoViewModel>>(pedidos);
            return View(pedidosViewModel);
        }

        [HttpGet]
        public IActionResult IngresaPedido()
        {
            List<CadeteModel> cadetesCargados = _repoCad.listarTodos();
            var cadetesViewModel = _mapper.Map<List<CadeteViewModel>>(cadetesCargados);
            return View(cadetesViewModel);
        }
        
        [HttpPost]
        public IActionResult IngresaPedido(string observacion, string datosExtraDireccion, string estado, int cadeteAcargo, int idUsuario)
        {
            //helper help = new helper(path, ext);
            //List<PedidoModel> pedidosAlmacenados = help.pedidosAlmacenados();
            var pedidosCargados = _repo.listarTodos();
            int ultimoPedido = 0;
            foreach(var pedido in pedidosCargados)
            {
                ultimoPedido = pedido.getNroPedido();
            }
            //help.agregaPedido(new PedidoModel(ultimoPedido + 1, observacion, datosExtraDireccion, nombre, direccion, telefono, estado, cadeteAcargo));
            //var pedidos = help.pedidosAlmacenados();
            _repo.Insertar(new PedidoModel(ultimoPedido + 1, observacion, datosExtraDireccion, estado, cadeteAcargo, idUsuario));
            var pedidos = _repo.listarTodos();
            var pedidosViewModel = _mapper.Map<List<PedidoViewModel>>(pedidos);
            return View("Index", pedidosViewModel);
        }
        
    }
}
