using Microsoft.AspNetCore.Mvc;
using QuizSite.Domain.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace QuizSite.Api.Controllers;

class QuizController : ControllerBase
{
    private readonly QuizDbContext _dbContext;

    public QuizController(QuizDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("get-all-quizes")]
    public async Task<IActionResult> getAllQuizes() {
        var quizes = await _dbContext.Questions.ToArrayAsync();
        System.Console.WriteLine(quizes);
        return Ok(quizes);
    }
}