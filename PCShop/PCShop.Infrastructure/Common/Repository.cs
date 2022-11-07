using Microsoft.EntityFrameworkCore;
using PCShop.Infrastructure.Data;
using System.Linq.Expressions;

namespace PCShop.Infrastructure.Common
{
    /// <summary>
    /// Implementation of IRepository interface
    /// </summary>
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext dbContext;

        /// <summary>
        /// Constructor of Repository class
        /// </summary>
        /// <param name="dbContext">The dbContext that will be used</param>
        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Method for retrieving all entities of type T which satisfy a certain condition as no tracking entities
        /// </summary>
        /// <typeparam name="T">Type of the target entity</typeparam>
        /// <param name="condition">The condition that must be satisfied</param>
        /// <returns>Queryable expression tree</returns>
        public IQueryable<T> AllAsReadOnly<T>(Expression<Func<T, bool>> condition)
            where T : class
        {
            return this.DbSet<T>().Where(condition).AsNoTracking();
        }

        private DbSet<T> DbSet<T>()
            where T : class
        {
            return this.dbContext.Set<T>();
        }
    }
}
