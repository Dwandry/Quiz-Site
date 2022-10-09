using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using QuizSite.Contracts.Http;
using QuizSite.Domain.Services.Interfaces;

namespace QuizSite.Domain.Queries;

public class GetQuizQuestionsQuery : IRequest<GetQuizQuestionsQueryResult>
{
    public string Category { get; init; }
}

public class GetQuizQuestionsQueryResult
{
    public List<HttpQuestion> Questions { get; init; }
}

public class GetQuizQuestionsQueryHandler : IRequestHandler<GetQuizQuestionsQuery, GetQuizQuestionsQueryResult>
{
    private readonly IMapper _mapper;
    private readonly IQuizSiteService _quizService;


    public GetQuizQuestionsQueryHandler(IMapper mapper, IQuizSiteService quizService)
    {
        _mapper = mapper;
        _quizService = quizService;
    }

    public async Task<GetQuizQuestionsQueryResult> Handle(GetQuizQuestionsQuery request, CancellationToken cancellationToken)
    {
        var questions = await _quizService.GetQuizQuestionsByCategory(request, cancellationToken);

        return new GetQuizQuestionsQueryResult
        {
            Questions = questions.Select(x => _mapper.Map<HttpQuestion>(x)).ToList()
        };
    }
}