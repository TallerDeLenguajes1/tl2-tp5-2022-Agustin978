using NLog;

namespace Cadeteria.Repositorio
{
    public abstract class Repositorio<T> : IRepositorio<T>
    {
        protected static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _configuration;
        protected readonly string? cadenaConecta;

        protected Repositorio(IConfiguration configuracion)
        {
            _configuration = configuracion;
            cadenaConecta = _configuration.GetConnectionString("ConnectionString");
        }

        public abstract T? BuscarPorId(int id);
        public abstract void Insertar(T obj);
        public abstract List<T> listarTodos();
    }
}
