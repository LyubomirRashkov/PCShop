using System.Linq.Expressions;

namespace PCShop.Infrastructure.Common
{
    /// <summary>
    /// Abstraction of Repository
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Method to retrieve all entities of type T that satisfy a certain condition as no tracking entities
        /// </summary>
        /// <typeparam name="T">Type of the target entity</typeparam>
        /// <param name="condition">The condition that must be satisfied</param>
        /// <returns>Queryable expression tree</returns>
        IQueryable<T> AllAsReadOnly<T>(Expression<Func<T, bool>> condition) 
            where T : class;
    }
}
