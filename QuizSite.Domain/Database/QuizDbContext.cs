using Microsoft.EntityFrameworkCore;
using QuizSite.Contracts.Database;

namespace QuizSite.Domain.Database;

public class QuizDbContext : DbContext
{
    public DbSet<Question> Questions { get; init; }
    public DbSet<Choise> Choises { get; init; }

    public QuizDbContext() : base() {}
    public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) {}
}