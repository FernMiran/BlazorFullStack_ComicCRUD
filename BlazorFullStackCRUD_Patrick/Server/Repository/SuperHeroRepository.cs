using BlazorFullStackCRUD_Patrick.Server.Context;
using BlazorFullStackCRUD_Patrick.Server.Entity;
using BlazorFullStackCRUD_Patrick.Server.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlazorFullStackCRUD_Patrick.Server.Repository
{
	public class SuperHeroRepository : ISuperHeroRepository
	{
		private readonly AppDbContext _appDbContext;

        public SuperHeroRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<SuperHero> CreateSuperHero(SuperHero superHero)
		{
			_appDbContext.SuperHeroes.Add(superHero);
			await _appDbContext.SaveChangesAsync();
			return superHero;
		}

		public async Task<SuperHero> UpdateSuperHero(SuperHero superHero)
		{
			//_appDbContext.SuperHeroes.Add(superHero);
			await _appDbContext.SaveChangesAsync();
			return superHero;
		}

		public async Task DeleteSuperHero(int id)
		{
			var superHero = await GetSuperHeroById(id);

			_appDbContext.SuperHeroes.Remove(superHero);
			await _appDbContext.SaveChangesAsync();
		}

		public async Task<SuperHero> GetSuperHeroById(int id)
		{
			return await _appDbContext.SuperHeroes.Where(hero => hero.Id == id).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<SuperHero>> GetSuperHeroes()
		{
			return await _appDbContext.SuperHeroes.ToListAsync();
		}
	}
}
