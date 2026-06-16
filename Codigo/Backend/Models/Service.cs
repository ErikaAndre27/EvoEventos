using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Service : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid? IdCategory { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid? IdPricingUnit { get; set; }
        public int DurationHoursDefault { get; set; }
        public bool Available { get; set; }
        public bool External { get; set; }

        public CategoryService CategoryService { get; set; } = null!;
        public PricingUnit PricingUnit { get; set; } = null!;
        public RequestDetail RequestDetail { get; set; } = null!;
        public ICollection<ServiceResource>? ServiceResources { get; set; } = new List<ServiceResource>();
        public ICollection<QuotationDetail>? QuotationDetails { get; set; } = new List<QuotationDetail>();
        public ICollection<ReservationService>? ReservationServices { get; set; } = new List<ReservationService>();
    }
}