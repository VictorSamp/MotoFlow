using MotoFlow.Application.MembershipFees.CreateMembershipFee;

public class MembershipFeeApiService
{
    private readonly HttpClient _http;

    public MembershipFeeApiService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("MotoFlowApi");
    }

    public async Task<string?> CreateMembershipFee(
        Guid memberId,
        CreateMembershipFeeRequest request)
    {
        var response = await _http.PostAsJsonAsync(
            $"api/members/{memberId}/membership-fees",
            request);

        if (response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string?> DeleteMembershipFee(
        Guid memberId,
        Guid feeId)
    {
        var response = await _http.DeleteAsync(
            $"api/members/{memberId}/membership-fees/{feeId}");

        if (response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadAsStringAsync();
    }
}