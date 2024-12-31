using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Models
{
    public class Review
    {
        public Guid ReviewId { get; set; }
        
        public Guid FlashCardId { get; set; }
        
        public DateTime ReviewDate { get; set; }
        
        public int Rating { get; set; }  // Rating (1 = hard, 2 = good, 3 = easy)
    }
}
