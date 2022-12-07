namespace Cadeteria.Models
{
    public class CadeteModel
    {
        private string nombre;
        private string telefono;
        private float jornalCobra;
        //Debo agregar el listado de pedidos
        private List<int> pedidos = new List<int>();
        public string direccion;
        private int id;
        private static int autoincremental;
        
        public CadeteModel(string nombre, string telefono, float jornalCobra, string direccion)
        {
            autoincremental++;
            this.id = autoincremental;
            this.nombre = nombre;
            this.telefono = telefono;
            this.jornalCobra = jornalCobra;
            this.direccion = direccion;
            //this.pedidos = pedidos;
        }

        public CadeteModel(int id, string nombre, string telefono, float jornalCobra, string direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.telefono = telefono;
            this.jornalCobra = jornalCobra;
            this.direccion = direccion;
            //this.pedidos = pedidos;
        }

        public CadeteModel() { }

        /*
        public void calculaJornal()
        {
            foreach(var pedido in pedidos)
            {
                if(pedido.getEstado() == "Entregado")
                {
                    this.jornalCobra += 300;
                }
            }
        }
        */

        public void agregaPedido(int nroPedido)
        {
            pedidos.Add(nroPedido);
        }

        public void eliminaPedido(int nroPedido)
        {
            foreach(var pedido in pedidos)
            {
                if(pedido == nroPedido)
                {
                    pedidos.Remove(pedido);
                }
            }
        }

        public float getJornal() { return jornalCobra; }
        public int getID() { return id; }
        public string getNombre() { return nombre; }
        public string getTelefono() { return telefono; }
        public string getDireccion() { return direccion; }
        public List<int> getPedidos() { return pedidos; }

    }
}
