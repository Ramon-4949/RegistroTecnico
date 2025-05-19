using System.ComponentModel.DataAnnotations;

namespace RegistroTecnico.Models;

public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public string Nombres { get; set; } = null!;

    [Range(0.01, double.MaxValue, ErrorMessage = "El sueldo debe ser mayor que 0")]
    public double SueldoHora { get; set; }
}