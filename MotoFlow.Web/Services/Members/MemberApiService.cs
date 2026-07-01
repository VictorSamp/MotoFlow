using MotoFlow.Application.Members.CreateMember;
using MotoFlow.Application.Members.UpdateMember;
using System.Text.Json;
using System.Text.Json.Serialization;

public class MemberApiService
{
    private readonly HttpClient _http;

    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters =
        {
            new JsonStringEnumConverter()
        }
    };

    public MemberApiService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("MotoFlowApi");
    }

    public async Task<List<MemberDto>?> GetAllMembers()
    {
        return await _http.GetFromJsonAsync<List<MemberDto>>(
            "api/members",
            _options);
    }

    public async Task<MemberDto?> GetMemberById(Guid id)
    {
        return await _http.GetFromJsonAsync<MemberDto>(
            $"api/members/{id}",
            _options);
    }

    public async Task CreateMember(CreateMemberRequest request)
    {
        var response = await _http.PostAsJsonAsync(
            "api/members",
            request);

        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateMember(Guid id, UpdateMemberRequest request)
    {
        var response = await _http.PatchAsJsonAsync(
            $"api/members/{id}",
            request);

        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteMember(Guid id)
    {
        var response = await _http.DeleteAsync(
            $"api/members/{id}");

        response.EnsureSuccessStatusCode();
    }
}