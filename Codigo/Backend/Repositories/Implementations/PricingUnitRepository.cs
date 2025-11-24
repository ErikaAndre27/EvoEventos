using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEvoEventos.Repositories.Implementations
{
    public class PricingUnitRepository : IPricingUnitRepository
    {
        private readonly EvoeventosContext _context;
        public PricingUnitRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<PricingUnit> GetPricingUnit(Guid Id)
        {
            return await _context.PricingUnits.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<List<PricingUnit>> GetPricingUnits()
        {
            return await _context.PricingUnits.ToListAsync();
        }
        public async Task<bool> CreatePricingUnit(PricingUnit PricingUnit)
        {
            try
            {
                _context.PricingUnits.Add(PricingUnit);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<bool> DeletePricingUnit(Guid Id)
        {
            try
            {
                var PricingUnit = await _context.Roles.FindAsync(Id);
                if (PricingUnit == null)
                {
                    return false;
                }
                _context.Roles.Remove(PricingUnit);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }

        }
        public async Task<bool> UpdatePricingUnit(Guid Id, PricingUnit UpdatedPricingUnit)
        {
            try
            {
                var existingPricingUnit = await _context.PricingUnits.FindAsync(Id);
                if (existingPricingUnit == null)
                {
                    return false;
                }

                existingPricingUnit.Name = UpdatedPricingUnit.Name;
                existingPricingUnit.UpdatedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;

                _context.PricingUnits.Update(existingPricingUnit);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
