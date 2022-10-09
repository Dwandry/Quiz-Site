using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using QuizSite.Contracts.Database;
using QuizSite.Domain.Queries;

namespace QuizSite.Domain.Services.Interfaces;

public interface IQuizSiteService
{
    Task<List<Question>> GetQuizQuestionsByCategory(GetQuizQuestionsQuery request, CancellationToken cancellationToken);

    Task<List<Result>> GetUserResultsByName(GetUserResultsQuery request, CancellationToken cancellationToken);

    Task<int> InsertUserResultIntoDb(Result resultToInsert, CancellationToken cancellationToken);
}