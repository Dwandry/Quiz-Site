using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuizSite.Domain.Queries;
using QuizSite.Domain.Database;
using MediatR;
using QuizSite.Domain.Services.Interfaces;
using QuizSite.Domain.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddDbContext<QuizDbContext>((options) => _ = options.UseNpgsql("User ID=postgres;Password=12345;Host=localhost;Port=5432;Database=FinalQuiz;"));
        builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        builder.Services.AddMediatR(typeof(GetQuizQuestionsQuery));
        builder.Services.AddAutoMapper(typeof(AppMappingProfile));
        builder.Services.AddTransient(typeof(IQuizSiteService), typeof(QuizSiteService));

        var app = builder.Build();

        app.UseFileServer();

        app.MapControllers();

        app.Run();
    }
}