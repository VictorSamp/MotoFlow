using MotoFlow.Application.Activities.CreateActivity;
using MotoFlow.Application.Activities.Dtos;
using MotoFlow.Application.Activities.UpdateActivity;

public class ActivityApiService
{
    private readonly HttpClient _http;

    public ActivityApiService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("MotoFlowApi");
    }

    public async Task<List<ActivityDto>?> GetAllActivities()
    {
        return await _http.GetFromJsonAsync<List<ActivityDto>>("api/activities");
    }

    public async Task<ActivityDto?> GetActivityById(Guid id)
    {
        return await _http.GetFromJsonAsync<ActivityDto>($"api/activities/{id}");
    }

    public async Task<string?> CreateActivity(CreateActivityRequest request)
    {
        var response = await _http.PostAsJsonAsync(
            "api/activities",
            request);

        if (response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string?> UpdateActivity(Guid id, UpdateActivityRequest request)
    {
        var response = await _http.PatchAsJsonAsync(
            $"api/activities/{id}",
            request);

        if (response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string?> DeleteActivity(Guid id)
    {
        var response = await _http.DeleteAsync(
            $"api/activities/{id}");

        if (response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadAsStringAsync();
    }
}