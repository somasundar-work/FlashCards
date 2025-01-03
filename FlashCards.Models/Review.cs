﻿using System.ComponentModel.DataAnnotations;

namespace FlashCards.Models
{
    public class Review: BaseEntity
    {
        public Guid FlashCardId { get; set; }

        public DateTime ReviewDate { get; set; }
        
        public RatingStatus Rating { get; set; }  
    }
}
