using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finsmart_final.Entities
{
    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public string? TransactionName { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public string? Descriptions { get; set; }
        public double Amount { get; set; }
    }
}
