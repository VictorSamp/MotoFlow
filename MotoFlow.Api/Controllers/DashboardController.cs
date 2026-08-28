using Microsoft.AspNetCore.Mvc;
using MotoFlow.Application.Dashboard.GetDashboard;

namespace MotoFlow.Api.Controllers;

[ApiController]
[Route("api/dashboard")]
public class DashboardController : ControllerBase
{
    private readonly IGetDashboardUseCase _getDashboardUseCase;

    public DashboardController(IGetDashboardUseCase getDashboardUseCase)
    {
        _getDashboardUseCase = getDashboardUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetDashboard(CancellationToken cancellationToken)
    {
        var result = await _getDashboardUseCase.Execute(cancellationToken);

        return Ok(result);
    }
}