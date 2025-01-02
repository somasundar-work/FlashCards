using System;
using FlashCards.Models;

namespace FlashCards.Application.Service;

public class ReviewService
{
    public void GetReview(Card card, RatingStatus rating)
    {
        // card.EaseFactor += 0.1 - (5 - (int)rating) * (0.08 + (5 - (int)rating) * 0.02);
        card.EaseFactor = rating switch
        {
            RatingStatus.Forgot => Math.Max(1.3, card.EaseFactor - 0.2),
            RatingStatus.Easy => card.EaseFactor += 0.15,
            _ => card.EaseFactor,
        };
        card.Interval = rating switch
        {
            RatingStatus.Forgot => 1,
            RatingStatus.Hard => (int)(card.Interval * 1.12),
            RatingStatus.Good => (int)(card.Interval * card.EaseFactor),
            RatingStatus.Easy => (int)(card.Interval * card.EaseFactor * 1.13),
            _ => throw new ArgumentOutOfRangeException("rating out of range"),
        };
        card.NextReviewDate = DateTime.UtcNow.AddDays(card.Interval);
        card.ReviewCount++;
    }
}
