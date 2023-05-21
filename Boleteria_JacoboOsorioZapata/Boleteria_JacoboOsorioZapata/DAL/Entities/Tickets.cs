using System.ComponentModel.DataAnnotations;

namespace Boleteria_JacoboOsorioZapata.DAL.Entities
{
    public class Tickets
    {
        [Display(Name = "ID del ticket")]
        [Key]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public Guid Id { get; set; }

        [Display(Name = "Fecha de uso")]
        public DateTime? UseDate { get; set; }

        [Display(Name = "¿Se usó?")]
        public bool IsUsed { get; set; }

        [Display(Name = "Puerta de entrada")]
        public string? EntranceGate { get; set; }
    }
}
