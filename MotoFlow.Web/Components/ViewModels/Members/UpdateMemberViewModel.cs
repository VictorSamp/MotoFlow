using MotoFlow.Domain.Enums;

namespace MotoFlow.Web.Components.ViewModels.Members
{
    public class UpdateMemberViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public PatchLevel CurrentPatchLevel { get; set; }
    }
}
