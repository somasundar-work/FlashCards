using System;
using FlashCards.Models;

namespace FlashCards.Application.Service;

public class ReviewService
{
    public void GetReview(Card card, RatingStatus rating)
    {
        card.EaseFactor += 0.1 - (5 - (int)rating) * (0.08 + (5 - (int)rating) * 0.02);
        if (card.EaseFactor < 1.3)
            card.EaseFactor = 1.3;

        if ((int)rating < 3)
        {
            card.Interval = 1;
        }
        else
        {
            card.Interval = card.ReviewCount switch
            {
                0 => 1,
                1 => 6,
                _ => (int)(card.Interval * card.EaseFactor),
            };
            card.ReviewCount++;
        }
        card.NextReviewDate = DateTime.UtcNow.AddDays(card.Interval);
    }
}
