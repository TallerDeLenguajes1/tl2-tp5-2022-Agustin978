namespace Cadeteria.Models
{
    public class UsuarioModel
    {
        private string nombre;
        private string direccion;
        private string telefono;
        private static int autoincremental;
        private int id;
        private string permisos;

        public UsuarioModel(string nombre, string direccion, string telefono)
        {
            autoincremental++;
            this.id = autoincremental;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.permisos = "usuario";
        }

        public UsuarioModel(int id, string nombre, string direccion, string telefono, string permisos)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.permisos = permisos;
        }

        public UsuarioModel() { }

        //Metodos getter
        public string getNombre() { return nombre; }
        public string getDireccion() { return direccion; } 
        public string getTelefono() { return telefono; }
        public int getId() { return id; }
        public string getPermisos() { return permisos; }
    }
}
