using BlazorFullStackCRUD_Patrick.Shared;
using System.ComponentModel.DataAnnotations;

namespace BlazorFullStackCRUD_Patrick.Server.Entity
{
	public class SuperHero
	{
		[Key]
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string HeroName { get; set; }

		public Comic? Comic { get; set; }

		public int ComicId { get; set; }
	}
}
