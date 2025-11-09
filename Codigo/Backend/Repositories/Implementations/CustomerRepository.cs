using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEvoEventos.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly EvoeventosContext _context;
        public CustomerRepository(EvoeventosContext Context)
        {
            _context = Context;
        }
        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _context.Customers
                .Where(c => c.IsActive)
                .ToListAsync();

        }
        public async Task<Customer> CreateCustomer(Customer Customer)
        {
            await _context.Customers.AddAsync(Customer);
            await _context.SaveChangesAsync();
            return Customer;
        }
        public async Task<Customer> UpdateCustomer(Customer UpdatedCustomer)
        {
            _context.Customers.Update(UpdatedCustomer);
            await _context.SaveChangesAsync();
            return UpdatedCustomer;
        }
        public async Task<bool> DeleteCustomer(Guid Id)
        {
            var Customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == Id && c.IsActive);
            if (Customer == null)
                return false;
            Customer.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Customer> GetCustomerById(Guid Id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == Id && c.IsActive);
        }
        public async Task<List<Customer>> GetCustomersByName(string Name)
        {
            return await _context.Customers
                .Where(c=>c.Name.Contains(Name)&& c.IsActive).ToListAsync();
        }
        public async Task<Customer> GetCustomerByDocumentNumber(string DocumentNumber)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.DocumentNumber == DocumentNumber && c.IsActive);
        }
        public async Task<bool> CustomerExists(string DocumentNumber)
        {
            return await _context.Customers
            .AnyAsync(c => c.DocumentNumber == DocumentNumber && c.IsActive);
        }
    }
}
    
