using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Resource : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public Guid? IdCategoryResource { get; set; }
        public string Description { get; set; } = string.Empty;
        public string SerialCode { get; set; } = string.Empty;
        public string IdStatusResource { get; set; } = string.Empty;
        public DateOnly PurchaseDate { get; set; }
        public decimal Value { get; set; }
        public DateOnly LastMaintenanceDate { get; set; }
        public DateOnly NextMaintenanceDate { get; set; }
        public bool IsExternal { get; set; }
        public string ExternalProvider { get; set; } = string.Empty;
        public decimal ExternalCost { get; set; }

        public CategoryResource CategoryResource { get; set; } = null!;
        public StatusResource StatusResource { get; set; } = null!;
        public ICollection<ServiceResource>? ServiceResources { get; set; } = new List<ServiceResource>();
    }
}