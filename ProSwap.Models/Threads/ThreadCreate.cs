using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSwap.Models.Threads
{
    public class ThreadCreate
    {
        [Required]
        [MinLength(10, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(3000, ErrorMessage = "There are too many characters in this field.")]
        public string Content { get; set; }
    }
}
