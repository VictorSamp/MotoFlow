namespace MotoFlow.Application.MembershipFees.CreateMembershipFee
{
    public interface ICreateMembershipFeeUseCase
    {
        Task ExecuteAsync(string memberId, CreateMembershipFeeRequest createMembershipFeeRequest, CancellationToken cancellationToken);
    }
}
