using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using MediatR;
using Moq;

using QuizSite.Contracts.Database;
using QuizSite.Domain.Database;
using QuizSite.Domain.Queries;
using QuizSite.Domain.Services;
using QuizSite.Domain.Services.Interfaces;
using Shouldly;

namespace QuizSite.UnitTests.Queries;

public class GetUserResultsQueryTest
{
    private readonly Mock<IQuizSiteService> _quizService;
    private readonly IRequestHandler<GetUserResultsQuery, GetUserResultsQueryResult> _handler;
    private readonly IMapper _mapper;

    public GetUserResultsQueryTest()
    {
        _quizService = new Mock<IQuizSiteService>();
        _mapper = CreateMapperForTest();
        _handler = new GetUserResultsQueryHandler(_mapper, _quizService.Object);        
    }

    [Fact]
    public async Task UserResultsShouldBeFound()
    {
        //Arrange
        var fixture = new Fixture();
        fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => fixture.Behaviors.Remove(b));
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        var listOfUserResults = fixture.CreateMany<Result>(10)
            .OrderByDescending(x => x.DateOfQuizRun)
            .ToList();

        _quizService.Setup(x => x.getUserResultsByName(It.IsAny<GetUserResultsQuery>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(listOfUserResults));

        
        var query = new GetUserResultsQuery
        {
            Username = listOfUserResults[0].Username
        };
        //Act
        var result = await _handler.Handle(query, CancellationToken.None);

        //Assert
        result.ShouldNotBeNull();
        result.Results[0].DateOfQuizRun.ShouldBe(listOfUserResults[0].DateOfQuizRun);
        result.Results[0].QuizCategory.ShouldBe(listOfUserResults[0].QuizCategory);
        result.Results[0].Username.ShouldBe(listOfUserResults[0].Username);
        result.Results[0].Score.ShouldBe(listOfUserResults[0].Score);
    }

    private IMapper CreateMapperForTest()
    {
        var mappingConfig = new MapperConfiguration(mc => {
            mc.AddProfile(new AppMappingProfile());
        });
        IMapper mapper = mappingConfig.CreateMapper();
        return mapper;
    }
}