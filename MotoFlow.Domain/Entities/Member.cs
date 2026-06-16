namespace MotoFlow.Domain.Entities
{
    public class Member
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string PhoneNumber { get; private set; }

        public DateTime JoinDate { get; private set; }

        //public PatchLevel CurrentPatchLevel { get; private set; }

        //public MemberStatus Status { get; private set; }

        public Member(string name, string email, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number cannot be null or empty.");

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            JoinDate = DateTime.UtcNow;
        }
    }
}
