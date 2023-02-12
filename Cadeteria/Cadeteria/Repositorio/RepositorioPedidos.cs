using Cadeteria.Models;
using Microsoft.Data.Sqlite;

namespace Cadeteria.Repositorio
{
    public class RepositorioPedidos : Repositorio<PedidoModel>
    {
        public RepositorioPedidos(IConfiguration configuration) : base(configuration) { }

        public override PedidoModel? BuscarPorId(int nroPedido)
        {
            var consulta = $"SELECT * FROM pedidos WHERE nroPedido LIKE {nroPedido}";
            try
            {
                using(SqliteConnection conexion = new SqliteConnection(cadenaConecta))
                {
                    conexion.Open();
                    using(SqliteCommand command = new SqliteCommand(consulta, conexion))
                    {
                        command.Parameters.AddWithValue("@nroPedido", nroPedido);
                        var pedidoEncontrado = new PedidoModel();
                        using(var reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                pedidoEncontrado = new PedidoModel(reader.GetInt32(0),reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetInt32(4), reader.GetInt32(5));
                            }
                            conexion.Close();
                            return pedidoEncontrado;
                        }
                    }
                }
            }catch(Exception ex)
            {
                _logger.Error($"Error en la busqueda del pedido numero {nroPedido} - ERROR: {ex.Message}");
            }
            return null;
        }

        public override void Insertar(PedidoModel obj)
        {
            var consulta = $"INSERT INTO pedidos(nroPedido,observacion,datosExtraDireccion,estado,id_cadete,id_cliente) VALUES(@nroPedido,@observacion,@datosExtraDireccion,@estado,@id_cadete,@id_cliente)";
            try
            {
                using(SqliteConnection conexion = new SqliteConnection(cadenaConecta))
                {
                    conexion.Open();
                    using(SqliteCommand command = new SqliteCommand(consulta, conexion))
                    {
                        command.Parameters.AddWithValue("@nroPedido", obj.getNroPedido());
                        command.Parameters.AddWithValue("@observacion", obj.getObservacion());
                        command.Parameters.AddWithValue("@datosExtraDireccion", obj.getDatosExtraDireccion());
                        command.Parameters.AddWithValue("@estado", obj.getEstado());
                        command.Parameters.AddWithValue("@id_cadete", obj.getCadeteAcargo());
                        command.Parameters.AddWithValue("@id_cliente", obj.getIdCliente());
                        command.ExecuteNonQuery();
                    }
                    conexion.Close();
                }
            }catch(Exception ex)
            {
                _logger.Error($"Se produjo un error inesperado al ingresar el nuevo pedido nro: {obj.getNroPedido()} - Error: {ex.Message}");
            }
        }

        public override List<PedidoModel> listarTodos()
        {
            var consulta = "SELECT * FROM pedidos";
            try
            {
                using(SqliteConnection conexion = new SqliteConnection(cadenaConecta))
                {
                    conexion.Open();
                    List<PedidoModel> pedidos = new List<PedidoModel>();
                    using (SqliteCommand command = new SqliteCommand(consulta, conexion))
                    {
                        using(var reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                PedidoModel pedido = new PedidoModel(int.Parse(reader.GetString(0)), reader.GetString(1), reader.GetString(2), reader.GetString(3), int.Parse(reader.GetString(4)), int.Parse(reader.GetString(5)));
                                pedidos.Add(pedido);
                            }
                        }
                    }
                    conexion.Close();
                    return pedidos;
                }
            }catch(Exception ex)
            {
                _logger.Error($"Error al intentar obtener todos los pedidos almacenados.\nError: {ex.Message}");
            }
            return null;
        }
    }
}
