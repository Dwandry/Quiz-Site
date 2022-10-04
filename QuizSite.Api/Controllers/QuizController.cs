using Microsoft.AspNetCore.Mvc;
using QuizSite.Domain.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using QuizSite.Domain;
using MediatR;
using System.Threading;
using QuizSite.Domain.Commands;

namespace QuizSite.Api.Controllers;

public class QuizController : ControllerBase
{
    private readonly IMediator _mediator;

    public QuizController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-all-quizes")]
    public async Task<IActionResult> GetAllQuizes([FromQuery(Name = "category")] string category, CancellationToken cancellationToken) 
    {
        var command = new GetQuizQuestionsCommand
        {
            Category = category
        };
        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result.Questions);
    }
}