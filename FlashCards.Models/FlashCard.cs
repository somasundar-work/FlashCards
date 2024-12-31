using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashCards.Models
{
    public class FlashCard: BaseEntity
    {
        [ForeignKey("DeckId")]
        public Guid DeckId { get; set; }

        public required string Question { get; set; }

        public required string Answer { get; set; }

        public DateTime LastReviewed { get; set; }

        public int Interval { get; set; }  // Spaced repetition interval

        public RatingStatus EaseFactor { get; set; }  // Difficulty factor for SRS

        public ICollection<Review> Reviews { get; set; } = [];
    }
}
