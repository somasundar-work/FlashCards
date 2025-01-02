using FlashCards.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashCards.Context.Configs
{
    internal class CardsBuilderConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(
            Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Card> builder
        )
        {
            builder.HasMany(x => x.Reviews).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder
                .Property(x => x.LastStatus)
                .HasConversion(
                    o => o.ToString(),
                    o => (RatingStatus)Enum.Parse(typeof(RatingStatus), o)
                );
        }
    }
}
