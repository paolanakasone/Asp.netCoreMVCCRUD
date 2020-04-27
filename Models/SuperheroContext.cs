using Microsoft.EntityFrameworkCore;

namespace Asp.netCoreMVCCRUD.Models
{
    public class SuperheroContext : DbContext
    {
        public SuperheroContext(DbContextOptions<SuperheroContext> options) : base(options)
        {
        }

        public DbSet<Superhero> Superhero { get; set; }
    }
}
