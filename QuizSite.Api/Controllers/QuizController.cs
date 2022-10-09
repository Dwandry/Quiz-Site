using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using System.Threading;
using QuizSite.Domain.Queries;

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
        var command = new GetQuizQuestionsQuery
        {
            Category = category
        };
        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result.Questions);
    }
}