using MotoFlow.Application.MembershipFees.CreateMembershipFee;

public class MembershipFeeApiService
{
    private readonly HttpClient _http;

    private static readonly System.Text.Json.JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
    };

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

    public async Task<List<MotoFlow.Application.MembershipFees.Dtos.MembershipFeeOverviewDto>?> GetAllMembershipFees()
    {
        return await _http.GetFromJsonAsync<List<MotoFlow.Application.MembershipFees.Dtos.MembershipFeeOverviewDto>>(
            "api/membership-fees",
            JsonOptions);
    }

    public async Task<string?> PayMembershipFee(Guid memberId, Guid feeId)
    {
        var response = await _http.PatchAsync(
            $"api/members/{memberId}/membership-fees/{feeId}/pay",
            null);

        if (response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadAsStringAsync();
    }
}
