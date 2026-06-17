using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Members.ActivateMember;
using MotoFlow.Application.Members.CreateMember;
using MotoFlow.Application.Members.DeleteMember;
using MotoFlow.Application.Members.GetAllMembers;
using MotoFlow.Application.Members.GetMemberById;
using MotoFlow.Application.Members.UpdateMember;

namespace MotoFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IGetAllMembersUseCase _getAllUseCase;
        private readonly IGetMemberByIdUseCase _getByIdUseCase;
        private readonly ICreateMemberUseCase _createUseCase;
        private readonly IUpdateMemberUseCase _updateUseCase;
        private readonly IDeleteMemberUseCase _deleteUseCase;
        private readonly IActivateMemberUseCase _activateMemberUseCase;

        public MembersController(IGetAllMembersUseCase getAllUseCase,
            IGetMemberByIdUseCase getByIdUseCase,
            ICreateMemberUseCase createUseCase,
            IUpdateMemberUseCase updateUseCase,
            IDeleteMemberUseCase deleteUseCase,
            IActivateMemberUseCase activateMemberUseCase)
        {
            _getAllUseCase = getAllUseCase;
            _getByIdUseCase = getByIdUseCase;
            _createUseCase = createUseCase;
            _updateUseCase = updateUseCase;
            _deleteUseCase = deleteUseCase;
            _activateMemberUseCase = activateMemberUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMembers(CancellationToken cancellationToken)
        {
            var result = await _getAllUseCase.Execute(cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMemberById([FromRoute] string id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _getByIdUseCase.Execute(id, cancellationToken);
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
        public async Task<IActionResult> CreateMember([FromBody] CreateMemberRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _createUseCase.Execute(request, cancellationToken);

                return Created();
            }
            catch(EmailExistsException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> UpdateMember([FromRoute] string id, [FromBody] UpdateMemberRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _updateUseCase.Execute(id, request, cancellationToken);

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

        [HttpPatch]
        [Route("{id}/activate")]
        public async Task<IActionResult> ActivateMember([FromRoute] string id, CancellationToken cancellationToken)
        {
            try
            {
                await _activateMemberUseCase.Execute(id, cancellationToken);

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

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMember([FromRoute] string id, CancellationToken cancellationToken)
        {
            try
            {
                await _deleteUseCase.Execute(id, cancellationToken);

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
}
