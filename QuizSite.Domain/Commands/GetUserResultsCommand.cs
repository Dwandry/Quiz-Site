using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizSite.Contracts.Database;
using QuizSite.Contracts.Http;
using QuizSite.Domain.Database;

namespace QuizSite.Domain.Commands;

public class GetUserResultsCommand : IRequest<GetUserResultsCommandResult>
{
    public string Username { get; init; }
}

public class GetUserResultsCommandResult
{
    public List<HttpResult> Results { get; init; }
}

public class GetUserResultsCommandHandler : IRequestHandler<GetUserResultsCommand, GetUserResultsCommandResult>
{
    private readonly QuizDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserResultsCommandHandler(QuizDbContext dbContext, IMapper mapper = null)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetUserResultsCommandResult> Handle(GetUserResultsCommand request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Results.ToListAsync();
        var userResults = result.Where(x => x.Username == request.Username).ToList();
        List<HttpResult> httpResults = new List<HttpResult>();
        foreach (var userResult in userResults)
        {
            HttpResult httpResult = _mapper.Map<HttpResult>(userResult);
            String.Format("{0:F}", httpResult.DateOfQuizRun);
            httpResults.Add(httpResult);
        }
        return new GetUserResultsCommandResult
        {
            Results = httpResults
        };
    }
}