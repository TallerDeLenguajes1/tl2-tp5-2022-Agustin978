using System.ComponentModel.DataAnnotations;

namespace Cadeteria.ViewModels.Cadete
{
    public class CadeteViewModel
    {
        [Required]
        public int id { get; set; }

        [Required][StringLength(80)]
        public string nombre { get; set; }

        [Required][StringLength(150)]
        public string direccion { get; set; }

        [Required]
        [StringLength(100)]
        [Phone]
        public string telefono { get; set; }

        [Required]
        public float jornalACobrar { get; set; }

        public CadeteViewModel(string nombre, string direccion, string telefono, float jornalACobrar)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.jornalACobrar = jornalACobrar;
        }
    }
}
