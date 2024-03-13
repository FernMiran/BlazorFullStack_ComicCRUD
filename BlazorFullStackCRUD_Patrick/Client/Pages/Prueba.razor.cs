using BlazorFullStackCRUD_Patrick.Client.Services.ComicService;
using BlazorFullStackCRUD_Patrick.Client.Services.SuperHeroService;
using BlazorFullStackCRUD_Patrick.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace BlazorFullStackCRUD_Patrick.Client.Pages
{
	public class PruebaBase : ComponentBase
	{
		[Inject]
		public ISuperHeroService SuperHeroService { get; set; }

		[Inject]
		public IComicService ComicService { get; set; }

		[Parameter]
		public int? Id { get; set; }

		public string buttonText = string.Empty;

		public SuperHeroDTO hero = new SuperHeroDTO();

		protected override async Task OnInitializedAsync()
		{
			buttonText = Id == null ? "Create" : "Update";
			await ComicService.GetComics();
		}

		protected override async Task OnParametersSetAsync()
		{
			if (Id == null)
			{
				// For when creating
			}
			else
			{
				hero = await SuperHeroService.GetSingleHero((int)Id);
			}
		}

		public async void HandleSubmit()
		{
			if (Id == null)
			{
				await SuperHeroService.CreateSuperHero(hero);
			}
			else
			{
				await SuperHeroService.UpdateSuperHero(hero);
			}
		}

		public async void DeleteHero()
		{
			await SuperHeroService.DeleteSuperHero(hero.Id);
		}
	}
}
