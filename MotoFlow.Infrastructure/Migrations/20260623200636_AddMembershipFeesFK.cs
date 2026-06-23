using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMembershipFeesFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MembershipFees_MemberId",
                table: "MembershipFees");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipFees_MemberId_ReferencePeriod",
                table: "MembershipFees",
                columns: new[] { "MemberId", "ReferencePeriod" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MembershipFees_MemberId_ReferencePeriod",
                table: "MembershipFees");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipFees_MemberId",
                table: "MembershipFees",
                column: "MemberId");
        }
    }
}
