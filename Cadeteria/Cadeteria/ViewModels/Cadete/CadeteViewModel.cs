﻿using Cadeteria.Models;
using System.ComponentModel.DataAnnotations;

namespace Cadeteria.ViewModels.Cadete
{
    public class CadeteViewModel
    {
        
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


        public CadeteViewModel(int id,string nombre, string telefono, float jornalACobrar, string direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.jornalACobrar = jornalACobrar;
        }

        public CadeteViewModel() { }
    }
}
