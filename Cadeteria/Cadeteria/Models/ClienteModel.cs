namespace Cadeteria.Models
{
    public class ClienteModel
    {
        private string nombre;
        private string direccion;
        private string telefono;
        private static int autoincremental;
        private int id;

        public ClienteModel(string nombre, string direccion, string telefono)
        {
            autoincremental++;
            this.id = autoincremental;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        //Metodos getter
        public string getNombre() { return nombre; }
        public string getDireccion() { return direccion; } 
        public string getTelefono() { return telefono; }
        public int getId() { return id; }
    }
}
