using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEvoEventos.Models
{
    public class CustomerType
    {
        [Key]
        [Column ("IdCustomerType")]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        [Column("CreatedAT")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Column("UpdateAT")]
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        public ICollection<Customer>? Customers { get; set; } = new List<Customer>();

    }
}
