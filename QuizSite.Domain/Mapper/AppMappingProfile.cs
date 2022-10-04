using AutoMapper;
using QuizSite.Contracts.Database;
using QuizSite.Contracts.Http;

public class AppMappingProfile : Profile
{
		public AppMappingProfile()
		{			
			CreateMap<Result, HttpResult>();
		}
}