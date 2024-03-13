using BlazorFullStackCRUD_Patrick.Shared.DTO;
using System.Net.Http.Json;

namespace BlazorFullStackCRUD_Patrick.Client.Services.ComicService
{
	public class ComicService : IComicService
	{
		private readonly HttpClient _httpClient;

		public ComicService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public List<ComicDTO> Comics { get; set; } = new List<ComicDTO>();

		private string BASE_URL = "https://localhost:7087/";

		public async Task<ComicDTO> GetComic(int id)
		{
			var response = await _httpClient.GetAsync($"{BASE_URL}api/comic/{id}");

			if (response.IsSuccessStatusCode)
			{
				var result = await _httpClient.GetFromJsonAsync<ComicDTO>($"{BASE_URL}api/comic/{id}");
				return result;
			}
			else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				return null;
			}
			else
			{
				throw new Exception("Error fetching hero!");
			}
		}

		public async Task GetComics()
		{
			var result = await _httpClient.GetFromJsonAsync<List<ComicDTO>>($"{BASE_URL}api/comic/GetComics");
			if (result != null)
			{
				Comics = result;
			}
		}
	}
}
