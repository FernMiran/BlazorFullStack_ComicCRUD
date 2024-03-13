//using BlazorFullStackCRUD_Patrick.Server.Entity;
using BlazorFullStackCRUD_Patrick.Client.Pages;
using BlazorFullStackCRUD_Patrick.Shared.DTO;

namespace BlazorFullStackCRUD_Patrick.Client.Services.SuperHeroService
{
    public interface ISuperHeroService
	{
		List<SuperHeroDTO> Heroes { get; set; }

		Task CreateSuperHero(SuperHeroDTO superHero);
		Task UpdateSuperHero(SuperHeroDTO superHero);
		Task DeleteSuperHero(int id);

		Task GetSuperHeroes();
        Task<SuperHeroDTO> GetSingleHero(int id);
    }
}
