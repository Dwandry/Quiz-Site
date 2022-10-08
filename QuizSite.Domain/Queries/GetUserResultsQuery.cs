using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizSite.Contracts.Http;
using QuizSite.Domain.Database;

namespace QuizSite.Domain.Queries;

public class GetUserResultsQuery : IRequest<GetUserResultsQueryResult>
{
    public string Username { get; init; }
}

public class GetUserResultsQueryResult
{
    public List<HttpResult> Results { get; init; }
}

public class GetUserResultsQueryHandler : IRequestHandler<GetUserResultsQuery, GetUserResultsQueryResult>
{
    private readonly QuizDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserResultsQueryHandler(QuizDbContext dbContext, IMapper mapper = null)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetUserResultsQueryResult> Handle(GetUserResultsQuery request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Results
            .Where(x => x.Username == request.Username)
            .ToListAsync(cancellationToken);

        var httpResults = result
            .Select(x => _mapper.Map<HttpResult>(x))
            .OrderByDescending(x => x.DateOfQuizRun)
            .ToList();

        return new GetUserResultsQueryResult
        {
            Results = httpResults
        };
    }
}