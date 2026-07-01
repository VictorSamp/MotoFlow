using MotoFlow.Domain.Enums;

namespace MotoFlow.Application.Members.UpdateMember
{
    public class UpdateMemberRequest
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public PatchLevel PatchLevel { get; set; }

        public UpdateMemberRequest(string name, string phoneNumber, PatchLevel patchLevel)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            PatchLevel = patchLevel;
        }
    }
}
