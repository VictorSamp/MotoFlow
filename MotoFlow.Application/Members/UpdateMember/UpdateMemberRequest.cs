namespace MotoFlow.Application.Members.UpdateMember
{
    public record UpdateMemberRequest(string Name,
        string PhoneNumber,
        string PatchLevel
    );
}
