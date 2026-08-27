using Microsoft.AspNetCore.Mvc;
using MotoFlow.Application.Activities.CreateActivity;
using MotoFlow.Application.Activities.DeleteActivity;
using MotoFlow.Application.Activities.GetActivityById;
using MotoFlow.Application.Activities.GetAllActivities;
using MotoFlow.Application.Activities.UpdateActivity;
using MotoFlow.Application.Commom.Exceptions;

namespace MotoFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivitiesController : ControllerBase
{
    private readonly IGetAllActivitiesUseCase _getAllActivitiesUseCase;
    private readonly IGetActivityByIdUseCase _getActivityByIdUseCase;
    private readonly ICreateActivityUseCase _createActivityUseCase;
    private readonly IUpdateActivityUseCase _updateActivityUseCase;
    private readonly IDeleteActivityUseCase _deleteActivityUseCase;

    public ActivitiesController(
        IGetAllActivitiesUseCase getAllActivitiesUseCase,
        IGetActivityByIdUseCase getActivityByIdUseCase,
        ICreateActivityUseCase createActivityUseCase,
        IUpdateActivityUseCase updateActivityUseCase,
        IDeleteActivityUseCase deleteActivityUseCase)
    {
        _getAllActivitiesUseCase = getAllActivitiesUseCase;
        _getActivityByIdUseCase = getActivityByIdUseCase;
        _createActivityUseCase = createActivityUseCase;
        _updateActivityUseCase = updateActivityUseCase;
        _deleteActivityUseCase = deleteActivityUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllActivities(
        CancellationToken cancellationToken)
    {
        var result = await _getAllActivitiesUseCase.ExecuteAsync(
            cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetActivityById(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await _getActivityByIdUseCase.ExecuteAsync(
                id,
                cancellationToken);

            return Ok(result);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity(
        [FromBody] CreateActivityRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            await _createActivityUseCase.ExecuteAsync(
                request,
                cancellationToken);

            return Created();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (BadRequestException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ConflictException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> UpdateActivity(
        [FromRoute] Guid id,
        [FromBody] UpdateActivityRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            await _updateActivityUseCase.ExecuteAsync(
                id,
                request,
                cancellationToken);

            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (BadRequestException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ConflictException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteActivity(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        try
        {
            await _deleteActivityUseCase.ExecuteAsync(
                id,
                cancellationToken);

            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (BadRequestException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}