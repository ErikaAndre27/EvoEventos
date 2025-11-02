using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface ICustomerTypeRepository
    {

        Task<List<CustomerType>> GetCustomerTypes();
        Task<CustomerType> GetCustomerType(Guid id);
        Task<bool> CreateCustomerType(Guid id, CustomerType customerType);
        Task<bool> UpdateCustomerType(Guid id, CustomerType updatedCustomerType);
        Task<bool> DeleteCustomerType(Guid id);

    }

}

