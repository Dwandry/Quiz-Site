using Microsoft.EntityFrameworkCore;
using QuizSite.Contracts.Database;

namespace QuizSite.Domain.Database;

public class QuizDbContext : DbContext
{
    public DbSet<Question> Questions { get; init; }
    public DbSet<Choise> Choises { get; init; }

    public QuizDbContext() : base() {}
    public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Choise>()
            .HasOne<Question>(x => x.Question)
            .WithMany(x => x.Choises);

        base.OnModelCreating(modelBuilder);
    }
}