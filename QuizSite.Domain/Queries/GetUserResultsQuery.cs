using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using QuizSite.Contracts.Http;
using QuizSite.Domain.Services.Interfaces;

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
    private readonly IMapper _mapper;
    private readonly IQuizSiteService _quizService;


    public GetUserResultsQueryHandler(IMapper mapper, IQuizSiteService quizService)
    {
        _mapper = mapper;
        _quizService = quizService;
    }

    public async Task<GetUserResultsQueryResult> Handle(GetUserResultsQuery request, CancellationToken cancellationToken)
    {
        var result = await _quizService.GetUserResultsByName(request, cancellationToken);

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