using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSwap.Models.Transaction
{
    public class TransactionCreate
    {
        public Guid Buyer { get; set; }
        public Guid Seller { get; set; }
        //public List<> Game { get; set; }

    }
}
