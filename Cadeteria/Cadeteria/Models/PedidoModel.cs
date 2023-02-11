namespace Cadeteria.Models
{
    public class PedidoModel
    {
        private static int autoincremental;
        private int nroPedido;
        private string observacion;
        private string datosExtraDireccion;
        private string estado;
        //private ClienteModel cliente;
        private int cadeteAcargo;
        private int idCliente;

        public PedidoModel(string observacion, string datosExtraDireccion, string estado, int cadeteAcargo, int idCliente)
        {
            autoincremental++;
            this.nroPedido = autoincremental;
            this.observacion = observacion;
            this.datosExtraDireccion = datosExtraDireccion;
            this.estado = estado;
            //this.cliente = AgregaCliente(nombre, direccion, telefono);
            this.cadeteAcargo = cadeteAcargo;
            this.idCliente = idCliente;
        }

        public PedidoModel(int nroPedido, string observacion, string datosExtraDireccion, string estado, int cadeteAcargo, int idCliente)
        {
            this.nroPedido = nroPedido;
            this.observacion = observacion;
            this.datosExtraDireccion = datosExtraDireccion;
            this.estado = estado;
            //this.cliente = AgregaCliente(nombre, direccion, telefono);
            this.cadeteAcargo = cadeteAcargo;
            this.idCliente = idCliente;
        }

        public PedidoModel() { }

        //Metodo para ingresar el cliente
        /*
        public ClienteModel AgregaCliente(string nombre, string direccion, string telefono)
        {
            return new ClienteModel(nombre, direccion, telefono);
        }*/

        //Metodos getter
        public int getNroPedido() { return nroPedido; }
        public string getObservacion() { return observacion; }
        public string getDatosExtraDireccion() { return datosExtraDireccion; }
        //public ClienteModel getCliente() { return cliente; }
        public string getEstado() { return estado; }
        public int getCadeteAcargo() { return cadeteAcargo; }
        public int getIdCliente() { return idCliente; }

        //Metodo setter
        public void setEstado(string estado)
        {
            this.estado = estado;
        }
    }
}
