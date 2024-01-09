using Microsoft.EntityFrameworkCore;

namespace RickAndMortyApp.Data.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<AppCharacter> Characters { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<FavoriteCharacter> FavoriteCharacters { get; set; }
    }
}
