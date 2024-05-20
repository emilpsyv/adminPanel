using homePrakticee.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace homePrakticee.DAL
{
    public class PrakticeContext : IdentityDbContext
    {
        public PrakticeContext(DbContextOptions<PrakticeContext> options) : base(options)
        {
        }
        public DbSet<Slider> Sliders { get; set; }
    }
}
