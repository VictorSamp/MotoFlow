using MotoFlow.Web.Components.ViewModels.Dashboard;

namespace MotoFlow.Web.Services;

public class DashboardApiService
{
    private readonly HttpClient _httpClient;

    public DashboardApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DashboardDto?> GetDashboard(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<DashboardDto>("api/dashboard", cancellationToken);
    }
}