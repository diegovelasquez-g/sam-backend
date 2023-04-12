using SAM.Infrastructure.Commons.Bases.Request;

namespace SAM.Infrastructure.Helpers
{
    public static class QueryableHelper
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, BasePaginationRequest pagination)
        {
            return query
                .Skip((pagination.NumPage - 1) * pagination.NumRecordPages)
                .Take(pagination.NumRecordPages);
        }
    }
}
