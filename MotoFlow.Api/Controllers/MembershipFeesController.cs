using Microsoft.AspNetCore.Mvc;
using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.MembershipFees.CreateMembershipFee;
using MotoFlow.Application.MembershipFees.DeleteMembershipFee;
using MotoFlow.Application.MembershipFees.GetMembershipFeeById;
using MotoFlow.Application.MembershipFees.PayMembershipFee;

namespace MotoFlow.Api.Controllers
{
    [ApiController]
    [Route("api/members/{memberId:guid}/membership-fees")]
    public class MembershipFeesController : ControllerBase
    {
        private readonly IGetMembershipFeeByIdUseCase _getMembershipFeeByIdUseCase;
        private readonly ICreateMembershipFeeUseCase _createMembershipFeeUseCase;
        private readonly IDeleteMembershipFeeUseCase _deleteMembershipFeeUseCase;
        private readonly IPayMembershipFeeUseCase _payMembershipFeeUseCase;

        public MembershipFeesController(IGetMembershipFeeByIdUseCase getMembershipFeeByIdUseCase,
            ICreateMembershipFeeUseCase createMembershipFeeUseCase,
            IDeleteMembershipFeeUseCase deleteMembershipFeeUseCase,
            IPayMembershipFeeUseCase payMembershipFeeUseCase)
        {
            _getMembershipFeeByIdUseCase = getMembershipFeeByIdUseCase;
            _createMembershipFeeUseCase = createMembershipFeeUseCase;
            _deleteMembershipFeeUseCase = deleteMembershipFeeUseCase;
            _payMembershipFeeUseCase = payMembershipFeeUseCase;
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

        [HttpPatch("{feeId}/pay")]
        public async Task<IActionResult> Pay(string memberId, string feeId, CancellationToken cancellationToken)
        {
            await _payMembershipFeeUseCase.ExecuteAsync(
                memberId,
                feeId,
                cancellationToken);

            return NoContent();
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
