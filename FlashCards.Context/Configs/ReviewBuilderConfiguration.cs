using FlashCards.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashCards.Context.Configs
{
    internal class ReviewBuilderConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .Property(x => x.Rating)
                .HasConversion(o => o.ToString(), o => (RatingStatus)Enum.Parse(typeof(RatingStatus), o));
        }
    }
}
