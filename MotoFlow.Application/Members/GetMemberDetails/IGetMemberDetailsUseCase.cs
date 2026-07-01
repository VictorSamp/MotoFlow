using MotoFlow.Application.Members.Dtos;

namespace MotoFlow.Application.Members.GetMemberDetails
{
    public interface IGetMemberDetailsUseCase
    {
        Task<MemberDetailsDto> ExecuteAsync(Guid memberId, CancellationToken cancellationToken);
    }
}
