using Microsoft.AspNetCore.Mvc;
using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.MembershipFees.CreateMembershipFee;
using MotoFlow.Application.MembershipFees.DeleteMembershipFee;
using MotoFlow.Application.MembershipFees.GetMembershipFeeById;

namespace MotoFlow.Api.Controllers
{
    [ApiController]
    [Route("api/members/{memberId:guid}/membership-fees")]
    public class MembershipFeesController : ControllerBase
    {
        private readonly IGetMembershipFeeByIdUseCase _getMembershipFeeByIdUseCase;
        private readonly ICreateMembershipFeeUseCase _createMembershipFeeUseCase;
        private readonly IDeleteMembershipFeeUseCase _deleteMembershipFeeUseCase;

        public MembershipFeesController(IGetMembershipFeeByIdUseCase getMembershipFeeByIdUseCase,
            ICreateMembershipFeeUseCase createMembershipFeeUseCase,
            IDeleteMembershipFeeUseCase deleteMembershipFeeUseCase)
        {
            _getMembershipFeeByIdUseCase = getMembershipFeeByIdUseCase;
            _createMembershipFeeUseCase = createMembershipFeeUseCase;
            _deleteMembershipFeeUseCase = deleteMembershipFeeUseCase;
        }

        [HttpGet]
        [Route("{feeId:guid}")]
        public async Task<IActionResult> GetMembershipFeeById([FromRoute] string memberId,
            [FromRoute] string feeId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _getMembershipFeeByIdUseCase.ExecuteAsync(memberId, feeId, cancellationToken);

                return Ok(result);
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

        [HttpPost]
        public async Task<IActionResult> CreateMembershipFee([FromRoute] string memberId,
            [FromBody] CreateMembershipFeeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _createMembershipFeeUseCase.ExecuteAsync( memberId, request, cancellationToken);

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
        }

        [HttpDelete]
        [Route("{feeId:guid}")]
        public async Task<IActionResult> DeleteMembershipFee([FromRoute] string memberId,
            [FromRoute] string feeId, CancellationToken cancellationToken)
        {
            try
            {
                await _deleteMembershipFeeUseCase.ExecuteAsync(memberId, feeId, cancellationToken);

                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
