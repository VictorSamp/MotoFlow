using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.Members.GetMemberById
{
    public interface IGetMemberByIdUseCase
    {
        public Task<Member> Execute(string id, CancellationToken cancellationToken);
    }
}
