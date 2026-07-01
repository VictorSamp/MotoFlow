using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Members.Dtos;
using MotoFlow.Application.Members.Interfaces;
using MotoFlow.Application.MembershipFees.Dtos;

namespace MotoFlow.Application.Members.GetMemberDetails
{
    public class GetMemberDetailsUseCase : IGetMemberDetailsUseCase
    {
        private readonly IMemberRepository _memberRepository;

        public GetMemberDetailsUseCase(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<MemberDetailsDto> ExecuteAsync(Guid memberId, CancellationToken cancellationToken)
        {
            var member = await _memberRepository
                .GetDetailsByIdAsync(memberId, cancellationToken);

            return member is null
                ? throw new NotFoundException($"Member ID {memberId} not found.")
                : new MemberDetailsDto
                {
                    Id = member.Id,
                    Name = member.Name,
                    Email = member.Email,
                    PhoneNumber = member.PhoneNumber,
                    JoinDate = member.JoinDate,
                    CurrentPatchLevel = member.CurrentPatchLevel,
                    Status = member.Status,
                    MembershipFees = [.. member.MembershipFees
                        .Where(x => x.MemberId == memberId)
                        .OrderBy(x => x.ReferencePeriod)
                        .Select(x => new MembershipFeeDto
                        {
                            Id = x.Id,
                            ReferencePeriod = x.ReferencePeriod,
                            Amount = x.Amount,
                            PaymentDate = x.PaymentDate,
                            Status = x.Status,
                            IsDeleted = x.IsDeleted,
                            DeletedAt = x.DeletedAt
                        })]
                };
        }
    }
}
