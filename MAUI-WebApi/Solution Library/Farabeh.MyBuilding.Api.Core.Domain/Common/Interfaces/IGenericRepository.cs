using System.Linq.Expressions;
using Farabeh.MyBuilding.Api.Core.Domain.Common.Dto;

namespace Farabeh.MyBuilding.Api.Core.Domain.Common.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<IDto>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int first = 0, int offset = 0);
    }
}
