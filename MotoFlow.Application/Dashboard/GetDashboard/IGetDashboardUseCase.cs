using MotoFlow.Application.Dashboard.Dtos;

namespace MotoFlow.Application.Dashboard.GetDashboard;

public interface IGetDashboardUseCase
{
    Task<DashboardDto> Execute(CancellationToken cancellationToken);
}