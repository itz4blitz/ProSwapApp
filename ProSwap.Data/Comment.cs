using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSwap.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "There aren't enough characters in this field.")]
        [MaxLength(125, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }

        [Required]
        [MinLength(25, ErrorMessage = "There aren't enough characters in this field.")]
        [MaxLength(5500, ErrorMessage = "There are too many characters in this field.")]
        public string Content { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
