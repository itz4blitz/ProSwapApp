using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProSwap.Models.Transaction
{
    public class TransactionListItem
    {
        public int TransactionId { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public Guid Buyer { get; set; }
        public Guid Seller { get; set; }
        //public List<Game> MyProperty { get; set; }
    }
}
