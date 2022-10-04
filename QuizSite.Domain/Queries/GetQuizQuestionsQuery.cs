using System.Collections.Generic;
using MediatR;
using QuizSite.Contracts.Database;

namespace QuizSite.Domain.Queries;

public class GetQuizQuestionsQuery : IRequest<List<Question>>
{
    
}