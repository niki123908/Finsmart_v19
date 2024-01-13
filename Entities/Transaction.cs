using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finsmart_final.Entities
{
    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public string? Title { get; set; }
        public string TransType { get; set; } = string.Empty;
        public string? Descriptions { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }



        public int UserId { get; set; }
        [ForeignKey("user_id")]
        public AppUser User { get; set; }

    }
}
