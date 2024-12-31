using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Models
{
    public class FlashCard
    {
        [Key]
        public Guid FlashCardId { get; set; }

        public Guid DeckId { get; set; }

        public required string Question { get; set; }

        public required string Answer { get; set; }

        public DateTime LastReviewed { get; set; }

        public int Interval { get; set; }  // Spaced repetition interval

        public int EaseFactor { get; set; }  // Difficulty factor for SRS

        public bool IsDeleted { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
