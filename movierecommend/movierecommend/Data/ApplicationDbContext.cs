using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using movierecommend.Models;

namespace movierecommend.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<movierecommend.Models.rating> rating { get; set; } = default!;
        public DbSet<movierecommend.Models.movie> movie { get; set; } = default!;
    }
}
