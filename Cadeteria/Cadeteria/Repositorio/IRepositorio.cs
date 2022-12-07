namespace Cadeteria.Repositorio
{
    public interface IRepositorio<T>
    {
        T? BuscarPorId(int id);
        void Insertar(T obj);
        List<T> listarTodos();
    }
}
