using System.ComponentModel.DataAnnotations;

namespace RegistroTecnico.Models;

public class Sistemas
{
    [Key]
    public int SistemaId { get; set; }
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre no debe contener numeros ni caracteres especiales.")]
    [Required(ErrorMessage = "Este campo es requerido")]
    public string Descripcion { get; set; }
    [Range(1, 100, ErrorMessage = "El nivel de complejidad debe estar entre 1 y 100.")]
    public double Complejidad { get; set; }
}
