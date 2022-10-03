using QuizSite.Domain.Database;
using QuizSite.Domain.Services;
using QuizSite.Domain.Interfaces;

namespace QuizSite.Domain;

public class Factory
{
    public static readonly IQuizService QuizService = new QuizService(new QuizDbContext());
}