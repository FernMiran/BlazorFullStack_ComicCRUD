using BlazorFullStackCRUD_Patrick.Client.Pages;
using BlazorFullStackCRUD_Patrick.Shared;
using BlazorFullStackCRUD_Patrick.Shared.DTO;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorFullStackCRUD_Patrick.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public SuperHeroService(HttpClient http, NavigationManager navigationManager)
        {
            _httpClient = http;
            _navigationManager = navigationManager;
        }

        public List<SuperHeroDTO> Heroes { get; set; } = new List<SuperHeroDTO>();

        private string BASE_URL = "https://localhost:7087/";


		public async Task CreateSuperHero(SuperHeroDTO superHero)
		{
            var result = await _httpClient.PostAsJsonAsync("api/superhero", superHero);
            //var response = await result.Content.ReadFromJsonAsync<SuperHeroDTO>();
			_navigationManager.NavigateTo("superheroes");
		}

		public async Task UpdateSuperHero(SuperHeroDTO superHeroDTO)
		{
			var result = await _httpClient.PutAsJsonAsync($"api/superhero/{superHeroDTO.Id}", superHeroDTO);
			//var response = await result.Content.ReadFromJsonAsync<SuperHeroDTO>();
            _navigationManager.NavigateTo("superheroes");
		}

		public async Task DeleteSuperHero(int id)
		{
			await _httpClient.DeleteAsync($"api/superhero/{id}");
			_navigationManager.NavigateTo("superheroes");
		}

		public async Task<SuperHeroDTO> GetSingleHero(int id)
		{
            var response = await _httpClient.GetAsync($"{BASE_URL}api/superhero/{id}");

            if (response.IsSuccessStatusCode)
			{
				var result = await _httpClient.GetFromJsonAsync<SuperHeroDTO>($"{BASE_URL}api/superhero/{id}");
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

        public async Task GetSuperHeroes()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SuperHeroDTO>>($"{BASE_URL}api/superhero/GetSuperHeroes");
            if (result != null)
            {
                Heroes = result; 
            }
        }
	}
}
