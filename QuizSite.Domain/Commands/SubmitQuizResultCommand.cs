using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizSite.Contracts.Database;
using QuizSite.Domain.Database;

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
    private readonly QuizDbContext _dbContext;

    public SubmitQuizResultCommandHandler(QuizDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<SubmitQuizResultCommandResult> Handle(SubmitQuizResultCommand request, CancellationToken cancellationToken)
    {
        var resultToSubmit = new Result
        {
            Score = request.Score,
            Username = request.Username,
            QuizCategory = request.Category,
            DateOfQuizRun = DateTime.UtcNow
        };

        var result = await _dbContext.Results.AddAsync(resultToSubmit, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new SubmitQuizResultCommandResult
        {
            Id = result.Entity.Id
        };
    }
}