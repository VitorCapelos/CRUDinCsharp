using Microsoft.EntityFrameworkCore;
using WebApplicationCRUD.Models;

namespace WebApplicationCRUD.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            :base(options) 
        { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Visitantes> Visitantes { get; set; }

    }
}
