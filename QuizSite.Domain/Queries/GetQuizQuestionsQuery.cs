using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizSite.Contracts.Database;
using QuizSite.Domain.Database;

namespace QuizSite.Domain.Queries;

public class GetQuizQuestionsQuery : IRequest<GetQuizQuestionsQueryResult>
{
    public string Category { get; init; }
}

public class GetQuizQuestionsQueryResult
{
    public List<Question> Questions { get; init; }
}

public class GetQuizQuestionsQueryHandler : IRequestHandler<GetQuizQuestionsQuery, GetQuizQuestionsQueryResult>
{
    private readonly QuizDbContext _dbContext;

    public GetQuizQuestionsQueryHandler(QuizDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetQuizQuestionsQueryResult> Handle(GetQuizQuestionsQuery request, CancellationToken cancellationToken)
    {
        var questions = await _dbContext.Questions.Include(x => x.Choises).ToListAsync(cancellationToken);
        var questionsWithCategory = questions.Where(x => x.QuizCategory == request.Category).ToList();
        return new GetQuizQuestionsQueryResult
        {
            Questions = questionsWithCategory
        };
    }
}