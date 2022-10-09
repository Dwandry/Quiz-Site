using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;

using QuizSite.Contracts.Database;
using QuizSite.Domain.Commands;
using QuizSite.Domain.Services.Interfaces;
using Shouldly;

namespace QuizSite.UnitTests.Queries;

public class SubmitQuizResultCommandTest
{
    private readonly Mock<IQuizSiteService> _quizService;
    private readonly IRequestHandler<SubmitQuizResultCommand, SubmitQuizResultCommandResult> _handler;

    public SubmitQuizResultCommandTest()
    {
        _quizService = new Mock<IQuizSiteService>();
        _handler = new SubmitQuizResultCommandHandler(_quizService.Object);        
    }

    [Fact]
    public async Task QuizQuestionsShouldBeFound()
    {
        //Arrange       

        _quizService.Setup(x => x.InsertUserResultIntoDb(It.IsAny<Result>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(new Random().Next(10, 100)));

        var command = new SubmitQuizResultCommand
        {
            Category = Guid.NewGuid().ToString(),
            Score = new Random().Next(),
            Username = Guid.NewGuid().ToString(),
        };

        //Act
        var result = await _handler.Handle(command, CancellationToken.None);

        //Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBeInRange(10, 100);
        result.ShouldBeOfType<SubmitQuizResultCommandResult>();
    }
}