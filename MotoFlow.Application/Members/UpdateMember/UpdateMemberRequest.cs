namespace MotoFlow.Application.Members.UpdateMember
{
    public class UpdateMemberRequest
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public UpdateMemberRequest(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
