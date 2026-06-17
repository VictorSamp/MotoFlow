using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Members.CreateMember;
using MotoFlow.Application.Members.GetAllMembers;
using MotoFlow.Application.Members.GetMemberById;

namespace MotoFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IGetAllMembersUseCase _getAllUseCase;
        private readonly IGetMemberByIdUseCase _getByIdUseCase;
        private readonly ICreateMemberUseCase _createUseCase;

        public MembersController(IGetAllMembersUseCase getAllUseCase,
            IGetMemberByIdUseCase getByIdUseCase,
            ICreateMemberUseCase createUseCase)
        {
            _getAllUseCase = getAllUseCase;
            _getByIdUseCase = getByIdUseCase;
            _createUseCase = createUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMembers(CancellationToken cancellationToken)
        {
            var result = await _getAllUseCase.Execute(cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMemberById(string id, CancellationToken cancellationToken)
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
            await _createUseCase.Execute(request, cancellationToken);

            return Created();
        }
    }
}
