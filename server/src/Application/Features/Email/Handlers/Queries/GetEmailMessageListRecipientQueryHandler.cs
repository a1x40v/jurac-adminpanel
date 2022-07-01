using Application.Common.Exceptions;
using Application.DTO.EmailMessage;
using Application.Features.Email.Requests.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Email.Handlers.Queries
{
    public class GetEmailMessageListRecipientQueryHandler : IRequestHandler<GetEmailMessageListRecipientQuery, ICollection<EmailMessageDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetEmailMessageListRecipientQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ICollection<EmailMessageDto>> Handle(GetEmailMessageListRecipientQuery request, CancellationToken cancellationToken)
        {
            var recipient = await _dbContext.AuthUsers
                .Include(x => x.AdminpanelEmailmessageRecipients)
                .FirstOrDefaultAsync(x => x.Id == request.RecipientId);

            if (recipient == null)
            {
                throw new NotFoundException("AuthUser", request.RecipientId);
            }

            return await _dbContext.AdminpanelEmailmessages
                .Where(x => x.RecipientId == recipient.Id)
                .OrderByDescending(x => x.SentAt)
                .ProjectTo<EmailMessageDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}