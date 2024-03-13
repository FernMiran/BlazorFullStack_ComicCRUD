using BlazorFullStackCRUD_Patrick.Server.Entity;

namespace BlazorFullStackCRUD_Patrick.Server.Repository.Interface
{
	public interface ISuperHeroRepository
	{
		public Task<SuperHero> CreateSuperHero(SuperHero superHero);
		public Task<SuperHero> UpdateSuperHero (SuperHero superHero);
		public Task DeleteSuperHero(int id);

		public Task<SuperHero> GetSuperHeroById(int id);
		public Task<IEnumerable<SuperHero>> GetSuperHeroes();

	}
}
