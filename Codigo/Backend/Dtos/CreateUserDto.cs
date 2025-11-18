using System;
using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Dtos
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(100)]
        public string Names { get; set; }

        [Required]
        [StringLength(100)]
        public string Surnames { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; }

        [Phone]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        public Guid IdDocumentType { get; set; }

        [Required]
        [StringLength(50)]
        public string DocumentNumber { get; set; }

        [Required]
        public Guid IdRole { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [Required]
        [MinLength(6)]
        [StringLength(128)]
        public string Password { get; set; }
    }
}
