using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashCards.Models
{
    public class Card : BaseEntity
    {
        [ForeignKey("DeckId")]
        public Guid DeckId { get; set; }

        public required string Question { get; set; }

        public required string Answer { get; set; }

        public DateTime LastReviewed { get; set; }

        public RatingStatus LastStatus { get; set; }

        public int ReviewCount { get; set; } = 0;

        public double EaseFactor { get; set; } = 2.5;

        public int Interval { get; set; } = 1;

        public DateTime NextReviewDate { get; set; }

        public ICollection<Review> Reviews { get; set; } = [];
    }
}
