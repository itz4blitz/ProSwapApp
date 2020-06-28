using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSwap.Models
{
    public class ThreadListItem
    {
        [DisplayName("Seller: ")]
        public Guid OwnerID { get; set; }
        [DisplayName("Created: ")]
        public DateTimeOffset CreatedOn { get; set; }
        [DisplayName("Modified: ")]
        public DateTimeOffset? LastModifiedOn { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public object ThreadID { get; set; }
    }
}
