using Microsoft.EntityFrameworkCore;
using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;

namespace BackEvoEventos.Repositories.Implementations
{
    public class CustomerTypeRepository : ICustomerTypeRepository
    {
        private readonly EvoeventosContext _context;
        public CustomerTypeRepository(EvoeventosContext context)
        {
            _context = context;
        }

        public async Task<CustomerType> GetCustomerType(Guid id)
        {
            return await _context.CustomerTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CustomerType>> GetCustomerTypes()
        {
            return await _context.CustomerTypes.ToListAsync();
        }

        public async Task<bool> CreateCustomerType(CustomerType customerType)
        {
            try
            {
                _context.CustomerTypes.Add(customerType);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<bool> DeleteCustomerType(Guid id)
        {
            try
            {
                var customerType = await _context.CustomerTypes.FindAsync(id);
                if (customerType == null)
                {
                    return false;
                }
                _context.CustomerTypes.Remove(customerType);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }

        }

        public async Task<bool> UpdateCustomerType(Guid id, CustomerType updatedCustomerType)
        {
            try
            {
                var existingCustomerType = await _context.CustomerTypes.FindAsync(id);
                if (existingCustomerType == null)
                {
                    return false;
                }
                existingCustomerType.Name = updatedCustomerType.Name;
                existingCustomerType.UpdateAt = DateTime.UtcNow;

                _context.CustomerTypes.Update(existingCustomerType);
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
