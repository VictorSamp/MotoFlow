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
}