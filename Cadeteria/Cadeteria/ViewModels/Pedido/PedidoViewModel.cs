using Cadeteria.Models;
using System.ComponentModel.DataAnnotations;

namespace Cadeteria.ViewModels.Pedido
{
    public class PedidoViewModel
    {
        [Required]
        public int nroPedido { get; set; }

        [Required][StringLength(180)]
        public string observacion { get; set; }

        [Required][StringLength(300)]
        public string datosdatosExtraDireccion { get; set; }

        [Required][StringLength(80)]
        public string estado { get; set; }

        //public ClienteModel cliente { get; set; }

        [Required]
        public int cadeteAcargo { get; set; }

        [Required]
        public int idCliente { get; set; }

        public PedidoViewModel(int nroPedido, string observacion, string datosdatosExtraDireccion, string estado, int cadeteAcargo, int idCliente)
        {
            this.nroPedido = nroPedido;
            this.observacion = observacion;
            this.datosdatosExtraDireccion = datosdatosExtraDireccion;
            this.estado = estado;
            //this.cliente = new ClienteModel(nombre, direccion, telefono);
            this.cadeteAcargo = cadeteAcargo;
            this.idCliente = idCliente;
        }

        public PedidoViewModel(){}
    }
}
