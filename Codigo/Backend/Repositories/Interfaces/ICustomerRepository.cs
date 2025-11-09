using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers(); 
        Task<Customer> CreateCustomer(Customer Customer);
        Task<Customer> UpdateCustomer(Customer UpdatedCustomer);
        Task<bool> DeleteCustomer(Guid Id);
        Task<Customer> GetCustomerById(Guid Id);
        Task<List<Customer>> GetCustomersByName(string Name);
        Task<Customer> GetCustomerByDocumentNumber(string DocumentNumber);
        Task<bool> CustomerExists(string DocumentNumber);
    }
}
