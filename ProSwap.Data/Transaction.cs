using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSwap.Data
{
    public class Transaction
    {
        public DateTimeOffset Timestamp { get; set; }
        [Key]
        public int TransactionId { get; set; }
        [Required]
        public Guid Buyer { get; set; }
        [Required]
        public Guid Seller { get; set; }
        public Game Game { get; set; }
        public decimal TotalPrice { get; set; }
        public double ProSwapFee { get; set; }
        public List<Comment> Comments { get; set; }
        public bool CompletedTransaction { get; set; }
        public bool PositiveTrade { get; set; }
        public double TradeScore { get; set; }
        [ForeignKey("OfferId")]
        public int OfferId { get; set; }
        public virtual Offer Offer { get; set; }

    }
}
