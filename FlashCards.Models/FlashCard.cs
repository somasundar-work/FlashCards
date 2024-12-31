using System.ComponentModel.DataAnnotations;

namespace FlashCards.Models
{
    public class FlashCard
    {
        [Key]
        public Guid FlashCardId { get; set; }

        public required string Question { get; set; }

        public required string Answer { get; set; }

        public DateTime LastReviewed { get; set; }

        public int Interval { get; set; }  // Spaced repetition interval

        public RatingStatus EaseFactor { get; set; }  // Difficulty factor for SRS

        public bool IsDeleted { get; set; }

        public ICollection<Review> Reviews { get; set; } = [];
    }
}
