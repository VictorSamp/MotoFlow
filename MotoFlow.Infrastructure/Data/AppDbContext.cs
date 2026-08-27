using Microsoft.EntityFrameworkCore;
using MotoFlow.Domain.Entities;

namespace MotoFlow.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Member> Members { get; set; }
    public DbSet<MembershipFee> MembershipFees { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<ActivityMember> ActivityMembers { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly);
    }
}