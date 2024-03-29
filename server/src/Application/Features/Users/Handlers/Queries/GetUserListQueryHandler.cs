using AutoMapper.QueryableExtensions;
using Application.Common.Pagination;
using Application.DTO.User;
using Application.Features.Users.Requests.Queries;
using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Application.Contracts.Common;
using Domain.Constants.User;

namespace Application.Features.Users.Handlers.Queries
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListVm>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ISortHelper<UserDto> _sortHelper;
        public GetUserListQueryHandler(ApplicationDbContext dbContext, IMapper mapper, ISortHelper<UserDto> sortHelper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _sortHelper = sortHelper;
        }

        public async Task<UserListVm> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.AuthUsers.ProjectTo<UserDto>(_mapper.ConfigurationProvider);

            // searching
            string search = request.QueryParams.Search.Trim().ToLower();
            if (!String.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search) ||
                                    x.LastName.ToLower().Contains(search) ||
                                    x.Id.ToString().Contains(search) ||
                                    x.Email.ToLower().Contains(search) ||
                                    x.PhoneNumber.ToLower().Contains(search));
            }

            // filtering
            var filteredQuery = query
                .Where(x => x.DateJoined >= request.QueryParams.MinDateJoined &&
                    x.DateJoined <= request.QueryParams.MaxDateJoined);

            if (!string.IsNullOrEmpty(request.QueryParams.DocStatuses))
            {
                string[] statuses = request.QueryParams.DocStatuses.Split(',');
                filteredQuery = filteredQuery.Where(x => statuses.Contains(x.SendingStatus));
            }

            if (request.QueryParams.DocExistStatus != null)
            {
                switch (request.QueryParams.DocExistStatus)
                {
                    case UserDocExistingStatus.Exist:
                        filteredQuery = filteredQuery.Where(x => x.DocumentsAmount != 0);
                        break;
                    case UserDocExistingStatus.NotExist:
                        filteredQuery = filteredQuery.Where(x => x.DocumentsAmount == 0);
                        break;
                }
            }

            // sorting
            var sortedQuery = _sortHelper.ApplySort(filteredQuery, request.QueryParams.OrderBy);

            var pagination = await Pagination<UserDto>.CreateAsync(sortedQuery, request.QueryParams);

            var users = await pagination.Query.ToListAsync();

            return new UserListVm { Users = users, Pagination = pagination.Result };
        }
    }
}