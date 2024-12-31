using System.ComponentModel.DataAnnotations;

namespace FlashCards.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
