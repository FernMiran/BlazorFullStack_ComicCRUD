using BlazorFullStackCRUD_Patrick.Shared.DTO;

namespace BlazorFullStackCRUD_Patrick.Client.Services.ComicService
{
	public interface IComicService
	{
		List<ComicDTO> Comics { get; set; }

		Task GetComics();
		Task<ComicDTO> GetComic(int id);
	}
}
