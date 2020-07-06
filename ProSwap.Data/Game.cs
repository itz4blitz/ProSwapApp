using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string CurrencyName { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
