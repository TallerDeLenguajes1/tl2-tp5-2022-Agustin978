namespace Cadeteria.Models
{
    public class PedidoModel
    {
        private static int autoincremental;
        private int nroPedido;
        private string observacion;
        private string datosExtraDireccion;
        private string estado;
        private ClienteModel cliente;

        
        public PedidoModel(string observacion, string datosExtraDireccion, string nombre, string direccion, string telefono, string estado)
        {
            autoincremental++;
            this.nroPedido = autoincremental;
            this.observacion = observacion;
            this.datosExtraDireccion = datosExtraDireccion;
            this.estado = estado;
            this.cliente = AgregaCliente(nombre, direccion, telefono);
        }

        public PedidoModel(int nroPedido, string observacion, string datosExtraDireccion, string nombre, string direccion, string telefono, string estado)
        {
            this.nroPedido = nroPedido;
            this.observacion = observacion;
            this.datosExtraDireccion = datosExtraDireccion;
            this.estado = estado;
            this.cliente = AgregaCliente(nombre, direccion, telefono);
        }

        //Metodo para ingresar el cliente
        public ClienteModel AgregaCliente(string nombre, string direccion, string telefono)
        {
            return new ClienteModel(nombre, direccion, telefono);
        }

        //Metodos getter
        public int getNroPedido() { return nroPedido; }
        public string getObservacion() { return observacion; }
        public string getDatosExtraDireccion() { return datosExtraDireccion; }
        public ClienteModel getCliente() { return cliente; }
        public string getEstado() { return estado; }

        //Metodo setter
        public void setEstado(string estado)
        {
            this.estado = estado;
        }
    }
}
