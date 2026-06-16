using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Dtos
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(150, ErrorMessage = "El nombre no puede superar los 150 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar una categoría.")]
        public Guid? IdCategory { get; set; }

        [Required(ErrorMessage = "El precio unitario es obligatorio.")]
        [Range(0.0, 9999999.99, ErrorMessage = "El precio unitario debe ser un valor positivo.")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una unidad de precio.")]
        public Guid? IdPricingUnit { get; set; }

        [Required(ErrorMessage = "Debe especificar la duración por defecto.")]
        [Range(0, 240, ErrorMessage = "La duración por defecto debe estar entre 0 y 240 horas.")]
        public int DurationHoursDefault { get; set; }

        public bool Available { get; set; }
        public bool External { get; set; }


        [Required(ErrorMessage = "El recurso es obligatorio.")]
        public Guid IdResource { get; set; }

        [Required(ErrorMessage = "La cantidad requerida es obligatoria.")]
        [Range(1, 9999, ErrorMessage = "La cantidad requerida debe ser mayor o igual a 1.")]
        public int QuantityRequired { get; set; }

        public bool IsMandatory { get; set; }

        [StringLength(300, ErrorMessage = "Las notas de uso no pueden superar los 300 caracteres.")]
        public string UsageNotes { get; set; } = string.Empty;
    }
}
