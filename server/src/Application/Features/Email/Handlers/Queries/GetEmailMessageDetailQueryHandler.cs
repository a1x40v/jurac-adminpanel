using Application.DTO.EmailMessage;
using Application.Features.Email.Requests.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Email.Handlers.Queries
{
    public class GetEmailMessageDetailQueryHandler : IRequestHandler<GetEmailMessageDetailQuery, EmailMessageDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetEmailMessageDetailQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<EmailMessageDto> Handle(GetEmailMessageDetailQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.AdminpanelEmailmessages
                .Where(x => x.Id == request.Id)
                .ProjectTo<EmailMessageDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}