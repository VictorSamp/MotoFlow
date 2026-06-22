namespace MotoFlow.Application.MembershipFees.DeleteMembershipFee
{
    public interface IDeleteMembershipFeeUseCase
    {
        Task ExecuteAsync(string memberId, string feeId, CancellationToken cancellationToken);
    }
}
