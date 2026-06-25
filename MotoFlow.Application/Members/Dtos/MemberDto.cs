using MotoFlow.Domain.Enums;

public class MemberDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime JoinDate { get; set; }
    public PatchLevel CurrentPatchLevel { get; set; }
}