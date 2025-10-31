using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface ICustomerTypeRepository
    {

        Task<List<CustomerType>> GetCustomerTypes();
        Task<CustomerType> GetCustomerType(int id);
    }

}

