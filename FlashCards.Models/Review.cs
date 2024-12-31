using System.ComponentModel.DataAnnotations;

namespace FlashCards.Models
{
    public class Review: BaseEntity
    {
        [Key]
        public Guid ReviewId { get; set; }
        
        public DateTime ReviewDate { get; set; }
        
        public RatingStatus Rating { get; set; }  
    }
}
