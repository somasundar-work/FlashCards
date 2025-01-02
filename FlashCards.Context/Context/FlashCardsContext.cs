using System.Reflection;
using FlashCards.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashCards.Context.Context
{
    public class FlashCardsContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Deck> Decks { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
