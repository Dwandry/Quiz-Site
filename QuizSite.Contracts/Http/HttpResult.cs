using System;

namespace QuizSite.Contracts.Http;

public class HttpResult
{    
    public string Username { get; set; }

    public string QuizCategory { get; set; }
    public int Score { get; set; }

    public DateTime DateOfQuizRun { get; set; }    
}