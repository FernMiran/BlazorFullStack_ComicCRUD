using AutoMapper;
using BlazorFullStackCRUD_Patrick.Server.Entity;
using BlazorFullStackCRUD_Patrick.Shared.DTO;

namespace BlazorFullStackCRUD_Patrick.Server.AutoMapper
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{
			CreateMap<SuperHero, SuperHeroDTO>();
			CreateMap<SuperHero, CreateSuperHeroDTO>();

			CreateMap<Comic, ComicDTO>();
		}
	}
}
