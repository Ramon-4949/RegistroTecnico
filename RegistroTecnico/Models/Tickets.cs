using System.ComponentModel.DataAnnotations;

namespace RegistroTecnico.Models
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }
        public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [Required(ErrorMessage ="Este campo es requerido")]
        public string Prioridad { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Asunto { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public double TiempoInvertido { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int TecnicoId { get; set; }

        public Clientes Cliente { get; set; }
        public Tecnicos Tecnico { get; set; }

    }
}
