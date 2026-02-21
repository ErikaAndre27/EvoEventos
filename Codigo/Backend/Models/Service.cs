using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEvoEventos.Models
{
    public class Service : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? IdCategory { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid? IdPricingUnit { get; set; }
        public int DurationHoursDefault { get; set; }
        public bool Available { get; set; }
        public bool External { get; set; }

        [ForeignKey("IdCategory")]
        public CategoryService? CategoryService { get; set; }

        [ForeignKey("IdPricingUnit")]
        public PricingUnit? PricingUnit { get; set; }
        public RequestDetail RequestDetail { get; set; }
        public ICollection<ServiceResource>? ServiceResources { get; set; } = new List<ServiceResource>();
        public ICollection<QuotationDetail>? QuotationDetails { get; set; } = new List<QuotationDetail>();
        public ICollection<ReservationService>? ReservationServices { get; set; } = new List<ReservationService>();
    }
}