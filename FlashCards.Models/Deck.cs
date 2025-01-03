﻿using System.ComponentModel.DataAnnotations;

namespace FlashCards.Models
{
    public class Deck : BaseEntity
    {
        public required string DeckName { get; set; }
        public required string Description { get; set; }
        public ICollection<Card> Flashcards { get; set; } = [];
    }
}
