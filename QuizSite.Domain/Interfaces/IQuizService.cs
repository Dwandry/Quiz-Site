using System.Collections.Generic;
using QuizSite.Contracts.Database;

namespace QuizSite.Domain.Interfaces;

public interface IQuizService
{
    List<Question> getQuestionsBasedOnCategory(string quizCategory);
}