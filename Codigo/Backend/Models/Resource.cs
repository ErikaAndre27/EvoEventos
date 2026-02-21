using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEvoEventos.Models
{
    public class Resource : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Guid? IdCategoryResource { get; set; }
        public string Description { get; set; }
        public string SerialCode { get; set; }
        public Guid IdStatusResource { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public decimal Value { get; set; }
        public DateOnly LastMaintenanceDate {  get; set; }
        public DateOnly NextMaintenanceDate { get; set; }
        public bool IsExternal { get; set; }
        public string ExternalProvider {  get; set; }
        public decimal ExternalCost { get; set; }

        [ForeignKey("IdCategoryResource")]
        public CategoryResource CategoryResource { get; set; }

        [ForeignKey("IdStatusResource")]
        public StatusResource StatusResource { get; set; }
        public ICollection<ServiceResource>? ServiceResources { get; set; } = new List<ServiceResource>();

    }
}