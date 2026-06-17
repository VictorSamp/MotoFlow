using Microsoft.EntityFrameworkCore;
using MotoFlow.Domain.Entities;

namespace MotoFlow.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

    }
}
