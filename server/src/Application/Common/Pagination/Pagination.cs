using Application.Common.QueryString;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Pagination
{
    public class Pagination<T>
    {
        public Pagination(IQueryable<T> paginatedQuery, PaginationResult result)
        {
            Query = paginatedQuery;
            Result = result;
        }
        public IQueryable<T> Query { get; set; }
        public PaginationResult Result { get; set; }
        public static async Task<Pagination<T>> CreateAsync(IQueryable<T> source, QueryParameters param)
        {
            var count = await source.CountAsync();
            var pagResult = new PaginationResult(count, param.PageNumber, param.PageSize);
            var query = source
                .Skip((pagResult.CurrentPage - 1) * pagResult.PageSize)
                .Take(pagResult.PageSize);


            return new Pagination<T>(query, pagResult);
        }
    }
}