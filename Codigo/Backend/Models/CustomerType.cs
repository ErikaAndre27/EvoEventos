using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEvoEventos.Models
{
    public class CustomerType: Auditory
    {
        [Key]
        [Column ("IdCustomerType")]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;

        public ICollection<Customer>? Customers { get; set; } = new List<Customer>();
    }
}
