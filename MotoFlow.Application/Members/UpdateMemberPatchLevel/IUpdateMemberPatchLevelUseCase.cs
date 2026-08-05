using MotoFlow.Domain.Enums;

namespace MotoFlow.Application.Members.UpdateMemberPatchLevel
{
    public interface IUpdateMemberPatchLevelUseCase
    {
        Task Execute(Guid id, PatchLevel patchLevel, CancellationToken cancellationToken);
    }
}
