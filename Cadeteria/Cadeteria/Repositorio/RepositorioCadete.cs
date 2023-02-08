using Cadeteria.Models;
using Microsoft.Data.Sqlite;

namespace Cadeteria.Repositorio
{
    public class RepositorioCadete : Repositorio<CadeteModel>
    {
        public RepositorioCadete(IConfiguration configuracion):base(configuracion){}

        public override CadeteModel BuscarPorId(int id)
        {
            string consulta = $"SELECT * FROM cadetes WHERE id LIKE {id}";
            try
            {
                using(SqliteConnection coneccion = new SqliteConnection(cadenaConecta))
                {
                    coneccion.Open();
                    using(SqliteCommand solicitud = new SqliteCommand(consulta, coneccion))
                    {
                        solicitud.Parameters.AddWithValue("@id", id);
                        CadeteModel cadeteEncontrado = new CadeteModel();
                        using(var reader = solicitud.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cadeteEncontrado = new CadeteModel(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetFloat(3), reader.GetString(4));
                            }
                        }
                        coneccion.Close();
                        return cadeteEncontrado;
                    }
                }
            }catch(Exception e)
            {
                _logger.Debug($"Error en la busqueda del cadete con id: {id} - Error: {e.Message}");
            }
            return null;
        }

        public override void Insertar(CadeteModel obj)
        {
            string consulta = "INSERT INTO cadetes(id, nombre, direccion, telefono, jornalCobra) VALUES(@id, @nombre, @direccion, @telefono, @jornalCobra)";
            try
            {
                using(SqliteConnection coneccion = new SqliteConnection(cadenaConecta))
                {
                    coneccion.Open();
                    using(SqliteCommand solicitud = new SqliteCommand(consulta, coneccion))
                    {
                        solicitud.Parameters.AddWithValue("@id", obj.getID());
                        solicitud.Parameters.AddWithValue("@nombre", obj.getNombre());
                        solicitud.Parameters.AddWithValue("@direccion", obj.getDireccion());
                        solicitud.Parameters.AddWithValue("@telefono", obj.getTelefono());
                        solicitud.Parameters.AddWithValue("@jornalCobra", obj.getJornal());
                        solicitud.ExecuteNonQuery();
                    }
                    coneccion.Close();
                }
            }catch(Exception ex)
            {
                _logger.Debug($"Error al intentar ingresar el cadete - ERROR: {ex.Message}");
            }
        }

        public override List<CadeteModel> listarTodos()
        {
            string consulta = "SELECT * FROM cadetes";
            try
            {

                //using var coneccion = new SqliteConnection(cadenaConecta);
                //var solicitud = new SqliteCommand(consulta, coneccion);
                using(SqliteConnection conexion = new SqliteConnection(cadenaConecta))
                {
                    conexion.Open();
                    SqliteCommand solicitud = new SqliteCommand(consulta, conexion);
                    
                    List<CadeteModel> cadetes = new List<CadeteModel>();
                    using(var reader = solicitud.ExecuteReader())
                    {
                        Console.WriteLine(reader.ToString());
                        while(reader.Read())
                        {
                            CadeteModel cadete = new CadeteModel(int.Parse(reader.GetString(0)), reader.GetString(1), reader.GetString(2), float.Parse(reader.GetString(3)), reader.GetString(4));
                            cadetes.Add(cadete);
                        }
                    }
                    conexion.Close();
                    return cadetes;
                }
            }catch(Exception ex)
            {
                _logger.Debug($"Error al intentar obtener los cadetes de la base de datos - ERROR: {ex.Message}");
            }
            return new List<CadeteModel>();
        }
    }
}
