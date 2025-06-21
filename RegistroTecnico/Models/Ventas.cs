using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnico.Models;

public class Ventas
{
    [Key]
    public int VentaId { get; set; }

    [Required]
    public DateTime Fecha { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "Debe Seleccionar un cliente")]
    public int ClienteId { get; set; }

    [InverseProperty("Venta")]
    public virtual ICollection<VentasDetalle> VentasDetalles { get; set; } = new List<VentasDetalle>();

    [ForeignKey("ClienteId")]
    public virtual Clientes Cliente { get; set; } = null!;
}