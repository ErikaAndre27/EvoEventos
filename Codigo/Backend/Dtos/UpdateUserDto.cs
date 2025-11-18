using System;
using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Dtos
{
    public class UpdateUserDto
    {
        [StringLength(100)]
        public string? Names { get; set; }

        [StringLength(100)]
        public string? Surnames { get; set; }

        [EmailAddress]
        [StringLength(150)]
        public string? Email { get; set; }

        [Phone]
        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(250)]
        public string? Address { get; set; }

        [MinLength(6)]
        [StringLength(128)]
        public string? CurrentPassword { get; set; }

        [MinLength(6)]
        [StringLength(128)]
        public string? NewPassword { get; set; }
    }
}
