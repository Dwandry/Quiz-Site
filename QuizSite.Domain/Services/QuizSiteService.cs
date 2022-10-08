using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizSite.Contracts.Database;
using QuizSite.Domain.Database;
using QuizSite.Domain.Queries;
using QuizSite.Domain.Services.Interfaces;

namespace QuizSite.Domain.Services;

public class QuizSiteService : IQuizSiteService
{
    private readonly QuizDbContext _dbContext;

    public QuizSiteService(QuizDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Question>> getQuizQuestionsByCategory(GetQuizQuestionsQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Questions
            .Include(x => x.Choises)
            .Where(x => x.QuizCategory == request.Category)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Result>> getUserResultsByName(GetUserResultsQuery request, CancellationToken cancellationToken)
    {
        return  await _dbContext.Results
            .Where(x => x.Username == request.Username)
            .ToListAsync(cancellationToken);

    }

    public async Task<int> insertUserResultIntoDb(Result resultToInsert, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Results.AddAsync(resultToInsert, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return result.Entity.Id;
    }
}