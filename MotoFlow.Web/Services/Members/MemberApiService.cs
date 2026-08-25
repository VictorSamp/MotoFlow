using MotoFlow.Application.Members.CreateMember;
using MotoFlow.Application.Members.Dtos;
using MotoFlow.Application.Members.UpdateMember;
using MotoFlow.Domain.Enums;
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

    public async Task<MemberDetailsDto?> GetMemberById(Guid id)
    {
        return await _http.GetFromJsonAsync<MemberDetailsDto>(
            $"api/members/{id}/details",
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

    public async Task<string?> UpdateMemberPatchLevel(Guid id, PatchLevel patchLevel)
    {
        var response = await _http.PatchAsJsonAsync(
            $"api/members/{id}/progression",
            patchLevel);

        if (response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadAsStringAsync();
    }

    public async Task DeleteMember(Guid id)
    {
        var response = await _http.DeleteAsync(
            $"api/members/{id}");

        response.EnsureSuccessStatusCode();
    }
}
