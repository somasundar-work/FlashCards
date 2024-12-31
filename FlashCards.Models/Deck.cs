using System;
using System.ComponentModel.DataAnnotations;

namespace FlashCards.Models
{
    public class Deck
    {
        [Key]
        public Guid DeckId { get; set; }
        public required string DeckName { get; set; }
        public required string Description { get; set; }
        public ICollection<FlashCard> Flashcards { get; set; } = [];
    }
}
