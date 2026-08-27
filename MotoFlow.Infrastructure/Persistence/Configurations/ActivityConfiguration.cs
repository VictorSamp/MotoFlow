using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoFlow.Domain.Entities;

namespace MotoFlow.Infrastructure.Persistence.Configurations;

public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Description)
            .HasMaxLength(1000);

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.EndDate)
            .IsRequired();

        builder.HasMany(x => x.ActivityMembers)
            .WithOne(x => x.Activity)
            .HasForeignKey(x => x.ActivityId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}