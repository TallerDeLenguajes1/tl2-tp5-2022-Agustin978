using System.ComponentModel.DataAnnotations;

namespace Cadeteria.ViewModels.Usuario
{
    public class UsuarioViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required][StringLength(100)]
        public string nombre { get; set; }

        [Required][StringLength(150)]
        public string direccion { get; set; }

        [Required][StringLength(20)][Phone]
        public string telefono { get; set; }

        [Required]
        public string permisos { get; set; }

        public UsuarioViewModel(int id, string nombre, string direccion, string telefono, string permisos)
        {
            Id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.permisos = permisos;
        }

        public UsuarioViewModel() { }
    }
}
