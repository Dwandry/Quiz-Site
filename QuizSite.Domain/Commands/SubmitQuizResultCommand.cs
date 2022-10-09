using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using QuizSite.Contracts.Database;
using QuizSite.Domain.Services.Interfaces;

namespace QuizSite.Domain.Commands;

public class SubmitQuizResultCommand : IRequest<SubmitQuizResultCommandResult>
{
    public int Score { get; init; }
    public string Username { get; init; }
    public string Category { get; init; }
}

public class SubmitQuizResultCommandResult
{
    public int Id { get; init; }
}

public class SubmitQuizResultCommandHandler : IRequestHandler<SubmitQuizResultCommand, SubmitQuizResultCommandResult>
{
    private readonly IQuizSiteService _quizService;

    public SubmitQuizResultCommandHandler(IQuizSiteService quizService)
    {
        _quizService = quizService;
    }

    public async Task<SubmitQuizResultCommandResult> Handle(SubmitQuizResultCommand request, CancellationToken cancellationToken)
    {
        var resultToInsert = new Result
        {
            Score = request.Score,
            Username = request.Username,
            QuizCategory = request.Category,
            DateOfQuizRun = DateTime.UtcNow
        };

        return new SubmitQuizResultCommandResult
        {
            Id = await _quizService.InsertUserResultIntoDb(resultToInsert, cancellationToken)
        };
    }
}