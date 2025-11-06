using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface ICustomerTypeRepository
    {

        Task<List<CustomerType>> GetCustomerTypes();
        Task<CustomerType> GetCustomerType(Guid Id);
        Task<bool> CreateCustomerType(CustomerType customerType);
        Task<bool> UpdateCustomerType(Guid Id, CustomerType updatedCustomerType);
        Task<bool> DeleteCustomerType(Guid Id);

    }

}

