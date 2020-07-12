using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSwap.Models.Transaction
{
    public class TransactionCreate
    {
        [Display(Name = "Buyer")]
        public Guid Buyer { get; set; }
        [Display(Name = "Seller")]
        public Guid Seller { get; set; }

    }
}
