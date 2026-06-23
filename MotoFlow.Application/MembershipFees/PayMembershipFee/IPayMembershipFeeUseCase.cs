namespace MotoFlow.Application.MembershipFees.PayMembershipFee
{
    public interface IPayMembershipFeeUseCase
    {
        public Task ExecuteAsync(string memberId, string feeId, CancellationToken cancellationToken);
    }
}
