using Microsoft.AspNetCore.Mvc;
using MotoFlow.Application.Members.CreateMember;

namespace MotoFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {

        private readonly ICreateMemberUseCase _useCase;

        public MembersController(ICreateMemberUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember([FromBody] CreateMemberRequest request)
        {
            await _useCase.Execute(request);

            return NoContent();
        }
    }
}
