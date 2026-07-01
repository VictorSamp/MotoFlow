using MotoFlow.Application.MembershipFees.Dtos;
using MotoFlow.Domain.Enums;

namespace MotoFlow.Application.Members.Dtos
{
    public class MemberDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; }
        public PatchLevel CurrentPatchLevel { get; set; }
        public MemberStatus Status { get; set; }
        public List<MembershipFeeDto> MembershipFees { get; set; } = [];
    }
}
