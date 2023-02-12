using Cadeteria.Models;
using Microsoft.Data.Sqlite;

namespace Cadeteria.Repositorio
{
    public class RepositorioUsuarios : Repositorio<UsuarioModel>
    {
        public RepositorioUsuarios(IConfiguration configuration):base(configuration) { }

        public override UsuarioModel BuscarPorId(int id)
        {
            var consulta = $"SELECT * FROM usuarios WHERE idCliente LIKE {id}";
            try
            {
                using(SqliteConnection conexion = new SqliteConnection(cadenaConecta))
                {
                    conexion.Open();
                    using(SqliteCommand command = new SqliteCommand(consulta, conexion))
                    {
                        command.Parameters.AddWithValue("@idCliente", id);
                        UsuarioModel usuarioEncontrado = new UsuarioModel();
                        using(var reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                usuarioEncontrado = new UsuarioModel(int.Parse(reader.GetString(0)), reader.GetString(1), reader.GetString(2),reader.GetString(3), reader.GetString(4));
                            }
                        }
                        return usuarioEncontrado;
                    }
                    conexion.Close();
                }
            }catch(Exception ex)
            {
                _logger.Error($"Error en la busqueda del usuario con ID: {id} - Error: {ex.Message}");
            }
            return null;
        }

        public override void Insertar(UsuarioModel obj)
        {
            var consulta = "INSERT INTO usuarios(idCliente, nombre, direccion, telefono, permisos) VALUES(@idCliente, @nombre, @direccion, @telefono, @permisos)";
            try
            {
                using(SqliteConnection conexion = new SqliteConnection(cadenaConecta))
                {
                    conexion.Open();
                    using (SqliteCommand solicitud = new SqliteCommand(consulta, conexion))
                    {
                        solicitud.Parameters.AddWithValue("@idCliente", obj.getId());
                        solicitud.Parameters.AddWithValue("@nombre", obj.getNombre());
                        solicitud.Parameters.AddWithValue("@direccion", obj.getDireccion());
                        solicitud.Parameters.AddWithValue("@telefono", obj.getTelefono());
                        solicitud.Parameters.AddWithValue("@permisos", obj.getPermisos());
                        solicitud.ExecuteNonQuery();
                    }
                    conexion.Close();
                }
            }catch(Exception ex)
            {
                _logger.Error($"Error al intentar ingresar al usuario - ERROR: {ex.Message}");
            }
        }

        public override List<UsuarioModel> listarTodos()
        {
            var consulta = "SELECT * FROM usuarios";
            try
            {
                using(SqliteConnection conexion = new SqliteConnection(cadenaConecta))
                {
                    conexion.Open();
                    SqliteCommand solicitud = new SqliteCommand(consulta, conexion);
                    List<UsuarioModel> usuarios = new List<UsuarioModel>();
                    using(var reader = solicitud.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            UsuarioModel user = new UsuarioModel(int.Parse(reader.GetString(0)),reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetString(4));
                            usuarios.Add(user);
                        }
                    }
                    conexion.Close();
                    return usuarios;
                }
            }catch(Exception ex)
            {
                _logger.Debug($"Error al intentar obtener todos los usuarios almacendos en la base de datos.\nError: {ex.Message}")
            }
            return null;
        }
    }
}
