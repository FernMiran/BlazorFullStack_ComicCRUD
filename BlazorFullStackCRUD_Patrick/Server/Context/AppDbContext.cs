using BlazorFullStackCRUD_Patrick.Server.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlazorFullStackCRUD_Patrick.Server.Context
{
	public class AppDbContext : DbContext
	{
		public DbSet<SuperHero> SuperHeroes { get; set; }
		public DbSet<Comic> Comics { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {  }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}
	}
}
