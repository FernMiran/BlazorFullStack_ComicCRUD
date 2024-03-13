using BlazorFullStackCRUD_Patrick.Client.Services.SuperHeroService;
using Microsoft.AspNetCore.Components;

namespace BlazorFullStackCRUD_Patrick.Client.Pages
{
	public class SuperHeroesBase : ComponentBase
	{
		[Inject]
		public ISuperHeroService SuperHeroService { get; set; }
		[Inject]
		public NavigationManager NavigationManager { get; set; }

		protected override async Task OnInitializedAsync()
		{
			await SuperHeroService.GetSuperHeroes();
		}

		void ShowHero(int id)
		{
			NavigationManager.NavigateTo($"/hero/{id}");
		}
	}
}
