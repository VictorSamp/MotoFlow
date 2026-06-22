using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoFlow.Domain.Entities;

namespace MotoFlow.Infrastructure.Persistence.Configurations
{
    public class MembershipFeeConfiguration : IEntityTypeConfiguration<MembershipFee>
    {
        public void Configure(EntityTypeBuilder<MembershipFee> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Amount)
                .HasPrecision(18, 2);

            builder.Property(x => x.MemberId)
                .IsRequired();

            builder.HasOne(x => x.Member)
                .WithMany(x => x.MembershipFees)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { 
                x.MemberId,
                x.ReferencePeriod
            }).IsUnique();
        }
    }
}
