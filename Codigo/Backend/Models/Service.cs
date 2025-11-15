using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Service : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? IdCategoryService { get; set; }
        public Guid? IdPricingUnit { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;

        public CategoryService CategoryService { get; set; }
        public PricingUnit PricingUnit { get; set; }
        public ICollection<ServiceResource>? ServiceResources { get; set; } = new List<ServiceResource>();
        public ICollection<QuotationDetail>? QuotationDetails { get; set; } = new List<QuotationDetail>();
        public ICollection<ReservationService>? ReservationServices { get; set; } = new List<ReservationService>();
    }
}