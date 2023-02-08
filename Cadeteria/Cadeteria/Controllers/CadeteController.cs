using Microsoft.AspNetCore.Mvc;
using System.Web;
using Cadeteria.Models;
using AutoMapper;
using Cadeteria.ViewModels.Cadete;
using Cadeteria.Repositorio;

namespace Cadeteria.Controllers
{
    public class CadeteController : Controller
    {
        private static string path = @"C:\Cursos\Programacion_UNT\Taller_de_Lenguajes_2\tl2-tp5-2022-Agustin978\Cadeteria\Cadeteria\Archivos\cadetes";
        private static string ext = ".csv";
        //List<CadeteModel> cadetes = new List<CadeteModel>();
        private readonly ILogger<CadeteController> _logger;
        private readonly IRepositorio<CadeteModel> _repo;
        private readonly IMapper _mapper;
       
        public CadeteController(ILogger<CadeteController> logger, IRepositorio<CadeteModel> repo,IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //helper help = new helper(path, ext);
            //var cadetes = help.cadetesAlmacenados();
            List<CadeteModel> cadetes = _repo.listarTodos(); //Enlista todos los cadetes almacenados en la base de datos
            //Mapeado de los datos almacenados
            var cadetesViewModel = _mapper.Map<List<CadeteViewModel>>(cadetes); //Los mapeo para pasarlos como CadeteViewModel
            return View(cadetesViewModel);
        }

        [HttpGet]
        public IActionResult IngresaCadete()
        {
            //string message = HttpUtility.HtmlEncode("Cadete.creaCadete, nombre:" + nombre + " ID: "+id);
            //var cadete = new CadeteModel(nombre, telefono, jornalCobra);
            return View(); 
        }

        [HttpPost]
        public IActionResult IngresaCadete(string nombre, string telefono, double jornalACobrar, string direccion)
        {
            //string path = @"C:\Cursos\Programacion_UNT\Taller_de_Lenguajes_2\tl2-tp5-2022-Agustin978\Cadeteria\Cadeteria\Archivos\cadetes";
            //string ext = ".csv";
            //helper help = new helper(path, ext);

            //List<CadeteModel> cadetesCargados = help.cadetesAlmacenados();
            var cadetesCargados = _repo.listarTodos();
            int ultimoId = 0;

            foreach(var cadete in cadetesCargados)
            {
                ultimoId = cadete.getID();
            }

            //help.agregaCadete(new CadeteModel(ultimoId+1 ,nombre, telefono, jornalACobrar, direccion));
            _repo.Insertar(new CadeteModel(ultimoId + 1, nombre, telefono, jornalACobrar, direccion)); //inserto el nuevo cadete
            //var cadetes = help.cadetesAlmacenados();
            var cadetes = _repo.listarTodos();
            var cadetesViewModel = _mapper.Map<List<CadeteViewModel>>(cadetes);
            return View("Index", cadetesViewModel);
        }
    }
}
