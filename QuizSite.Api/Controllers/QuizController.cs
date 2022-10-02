using Microsoft.AspNetCore.Mvc;
using QuizSite.Domain.Database;

namespace QuizSite.Api.Controllers;

class QuizController : ControllerBase
{
    private readonly QuizDbContext _dbContext;

    public QuizController(QuizDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}