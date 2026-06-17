using MotoFlow.Application.Commom.Exceptions;
using MotoFlow.Application.Members.Interfaces;
using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.Members.CreateMember
{
    public class CreateMemberUseCase : ICreateMemberUseCase
    {
        private readonly IMemberRepository _memberRepository;

        public CreateMemberUseCase(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task Execute(CreateMemberRequest request, CancellationToken cancellationToken)
        {
            var emailExists = await _memberRepository.EmailExistsAsync(request.Email, cancellationToken);

            if (emailExists)
            {
                throw new EmailExistsException("Email already in use");
            };

            var member = new Member(request.Name,
            request.Email,
            request.PhoneNumber);

            await _memberRepository.AddAsync(member, cancellationToken);
            await _memberRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
