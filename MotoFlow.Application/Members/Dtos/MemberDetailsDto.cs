using MotoFlow.Application.MembershipFees.Dtos;
using MotoFlow.Domain.Enums;

namespace MotoFlow.Application.Members.Dtos
{
    public class MemberDetailsDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public MemberStatus Status { get; set; }

        public List<MembershipFeeDto> MembershipFees { get; set; }
    }
}
