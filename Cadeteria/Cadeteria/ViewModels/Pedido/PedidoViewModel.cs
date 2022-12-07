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

        public ClienteModel cliente { get; set; }

        public PedidoViewModel(string observacion, string datosdatosExtraDireccion, string nombre, string direccion, string telefono, string estado)
        {
            this.observacion = observacion;
            this.datosdatosExtraDireccion = datosdatosExtraDireccion;
            this.estado = estado;
            this.cliente = new ClienteModel(nombre,direccion,telefono);
        }
    }
}
