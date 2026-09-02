using Microsoft.AspNetCore.Mvc;
using MotoFlow.Application.MembershipFees.GetAllMembershipFees;

namespace MotoFlow.Api.Controllers;

[ApiController]
[Route("api/membership-fees")]
public class MembershipFeesOverviewController : ControllerBase
{
    private readonly IGetAllMembershipFeesUseCase _getAllMembershipFeesUseCase;

    public MembershipFeesOverviewController(
        IGetAllMembershipFeesUseCase getAllMembershipFeesUseCase)
    {
        _getAllMembershipFeesUseCase = getAllMembershipFeesUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _getAllMembershipFeesUseCase.ExecuteAsync(cancellationToken);

        return Ok(result);
    }
}
