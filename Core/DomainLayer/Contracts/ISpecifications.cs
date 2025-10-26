using DomainLayer.Models;
using System.Linq.Expressions;
namespace DomainLayer.Contracts
{
    public interface ISpecifications<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {

        public Expression<Func<TEntity, bool>>? Criteria { get; }

        List<Expression<Func<TEntity, object>>> IncludeExpression { get; }

        Expression<Func<TEntity, object>>? OrderBy { get; }
        Expression<Func<TEntity, object>>? OrderByDescending { get; }
    }
}
