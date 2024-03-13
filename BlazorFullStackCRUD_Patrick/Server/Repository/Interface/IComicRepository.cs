using BlazorFullStackCRUD_Patrick.Server.Entity;

namespace BlazorFullStackCRUD_Patrick.Server.Repository.Interface
{
	public interface IComicRepository
	{
		public Task<IEnumerable<Comic>> GetComics();
		public Task<Comic> GetComic(int id);
	}
}
