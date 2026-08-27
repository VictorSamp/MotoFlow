using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoFlow.Domain.Entities;

namespace MotoFlow.Infrastructure.Persistence.Configurations;

public class ActivityMemberConfiguration
    : IEntityTypeConfiguration<ActivityMember>
{
    public void Configure(EntityTypeBuilder<ActivityMember> builder)
    {
        builder.HasKey(x => new
        {
            x.ActivityId,
            x.MemberId
        });

        builder.HasOne(x => x.Activity)
            .WithMany(x => x.ActivityMembers)
            .HasForeignKey(x => x.ActivityId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Member)
            .WithMany(x => x.ActivityMembers)
            .HasForeignKey(x => x.MemberId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}