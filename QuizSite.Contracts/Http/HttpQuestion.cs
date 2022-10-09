using System.Collections.Generic;
using QuizSite.Contracts.Database;

namespace QuizSite.Contracts.Http;
public class HttpQuestion
{
    public string QuizCategory { get; set; }

    public string QuizQuestion { get; set; }
    public virtual IEnumerable<Choise> Choises { get; set; }
}