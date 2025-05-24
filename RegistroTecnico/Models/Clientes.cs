using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnico.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        public DateOnly FechaIngreso { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        [StringLength(11, MinimumLength = 9, ErrorMessage = "El RNC debe tener entre 9 y 11 caracteres")]
        public string Rnc { get; set; } = string.Empty;

        [Range(1, 100000, ErrorMessage = "El limite de creditos debe estar entre 0 y 100,000.")]
        public double LimiteCredito { get; set; }

        [ForeignKey("TecnicoId")]
        public int TecnicoId { get; set; }

        public virtual Tecnicos? Tecnico { get; set; } 
    }
}
