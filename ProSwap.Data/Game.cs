using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSwap.Data
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
