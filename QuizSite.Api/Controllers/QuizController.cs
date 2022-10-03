using Microsoft.AspNetCore.Mvc;
using QuizSite.Domain.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using QuizSite.Domain;

namespace QuizSite.Api.Controllers;

public class QuizController : ControllerBase
{
    private readonly QuizDbContext _dbContext;

    public QuizController(QuizDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("get-all-quizes")]
    public async Task<IActionResult> getAllQuizes([FromQuery(Name = "category")] string category) {
        System.Console.WriteLine("category " + category);
        var quizes = Factory.QuizService.getQuestionsBasedOnCategory(category);
        return Ok(quizes);
    }
}