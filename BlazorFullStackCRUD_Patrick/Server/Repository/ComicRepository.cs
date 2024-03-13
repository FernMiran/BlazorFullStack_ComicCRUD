using BlazorFullStackCRUD_Patrick.Server.Context;
using BlazorFullStackCRUD_Patrick.Server.Entity;
using BlazorFullStackCRUD_Patrick.Server.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlazorFullStackCRUD_Patrick.Server.Repository
{
	public class ComicRepository : IComicRepository
	{
		private readonly AppDbContext _appDbContext;

        public ComicRepository(AppDbContext appDbContext)
        {
			_appDbContext = appDbContext;
        }

        public async Task<Comic> GetComic(int id)
		{
			return await _appDbContext.Comics.Where(comic => comic.Id == id).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Comic>> GetComics()
		{
			return await _appDbContext.Comics.ToListAsync();
		}
	}
}
