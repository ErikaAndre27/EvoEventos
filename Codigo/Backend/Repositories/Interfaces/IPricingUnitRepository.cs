using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IPricingUnitRepository
    { 
        Task<List<PricingUnit>> GetPricingUnits();
        Task<PricingUnit> GetPricingUnit(Guid Id);
        Task<bool> CreatePricingUnit(PricingUnit PricingUnit);
        Task<bool> UpdatePricingUnit(Guid Id, PricingUnit UpdatedPricingUnit); 
        Task<bool> DeletePricingUnit(Guid Id);
    }
}
