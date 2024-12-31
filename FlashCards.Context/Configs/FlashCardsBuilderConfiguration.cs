using FlashCards.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashCards.Context.Configs
{
    internal class FlashCardsBuilderConfiguration : IEntityTypeConfiguration<FlashCard>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<FlashCard> builder)
        {
            builder.HasMany(x => x.Reviews).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder
                .Property(x => x.EaseFactor)
                .HasConversion(o => o.ToString(), o => (RatingStatus)Enum.Parse(typeof(RatingStatus), o));

        }
    }
}
