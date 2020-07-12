using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSwap.Data
{
    public class Offer
    {
        [Key]
        [Display(Name = "Offer ID")]
        public int OfferId { get; set; }
        
        [Required]
        [Display(Name = "Owner")]
        public Guid OwnerId { get; set; }
        
        [Required]
        [Display(Name = "Offer Title")]
        [MinLength(10, ErrorMessage ="You must enter at least 10 characters for the title.")]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(3000, ErrorMessage = "Please shorten your message below 3000 characters and resubmit.")]
        [Display(Name = "Offer Body")]
        public string Content { get; set; }
        
        [Required]
        [Display(Name = "Created On")]
        public DateTimeOffset CreatedUTC { get; set; }
        
        [Display(Name = "Last Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}
