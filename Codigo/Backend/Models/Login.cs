using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Login
    {
        [Required] // Son campos requeridos
        public string UserName { get; set; } = string.Empty!;

        [Required]
        public string Password { get; set; } = string.Empty!; // No permite datos vacios

    }
}
