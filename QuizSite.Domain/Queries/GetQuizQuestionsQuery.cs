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
    private readonly QuizDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetQuizQuestionsQueryHandler(QuizDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetQuizQuestionsQueryResult> Handle(GetQuizQuestionsQuery request, CancellationToken cancellationToken)
    {
        var questions = await _dbContext.Questions
            .Include(x => x.Choises)
            .Where(x => x.QuizCategory == request.Category)
            .ToListAsync(cancellationToken);

        return new GetQuizQuestionsQueryResult
        {
            Questions = questions.Select(x => _mapper.Map<HttpQuestion>(x)).ToList()
        };
    }
}