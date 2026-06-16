using System;
using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Dtos
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(100)]
        public string Names { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Surnames { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Phone]
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public Guid IdDocumentType { get; set; }

        [Required]
        [StringLength(50)]
        public string DocumentNumber { get; set; } = string.Empty;

        [Required]
        public Guid IdRole { get; set; }

        [StringLength(250)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        [StringLength(128)]
        public string Password { get; set; } = string.Empty;
    }
}
