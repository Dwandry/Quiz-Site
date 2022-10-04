using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizSite.Contracts.Database;
using QuizSite.Domain.Database;
using QuizSite.Domain.Queries;

namespace QuizSite.Domain.Handlers;

class GetQuizQuestionsHandler : IRequestHandler<GetQuizQuestionsQuery, List<Question>>
{
    private readonly QuizDbContext _dbContext;

    public GetQuizQuestionsHandler(QuizDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Question>> Handle(GetQuizQuestionsQuery request, CancellationToken cancellationToken)
    {
        var questions = await _dbContext.Questions.Include(x => x.Choises).ToListAsync();
        System.Console.WriteLine(questions);
        return questions;
    }
}