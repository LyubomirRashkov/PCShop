﻿using System.Linq.Expressions;

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

		/// <summary>
		/// Method to retrieve all entities of type T that satisfy a certain condition
		/// </summary>
		/// <typeparam name="T">Type of the target entity</typeparam>
		/// <param name="condition">The condition that must be satisfied</param>
		/// <returns>Queryable expression tree</returns>
		IQueryable<T> All<T>(Expression<Func<T, bool>> condition) 
            where T : class;

		/// <summary>
		/// Method to save all made changes in a transaction
		/// </summary>
		/// <returns>The number of state entries written to the database</returns>
		Task<int> SaveChangesAsync();

        /// <summary>
        /// Method to get the first entity from the database according to a specific condition
        /// </summary>
        /// <typeparam name="T">Type of the target entity</typeparam>
        /// <param name="condition">The condition that must be satisfied</param>
        /// <returns>The entity or null</returns>
        Task<T?> GetByPropertyAsync<T>(Expression<Func<T, bool>> condition)
           where T : class;

        /// <summary>
        /// Method to add an entity to the database
        /// </summary>
        /// <typeparam name="T">Type of the entity</typeparam>
        /// <param name="entity">Entity to add</param>
        Task AddAsync<T>(T entity) 
            where T : class;

		/// <summary>
		/// Method to get the specific entity from the database by its unique identifier
		/// </summary>
		/// <typeparam name="T">Type of the target entity</typeparam>
		/// <param name="id">Entity's unique identifier</param>
		/// <returns>The entity or null</returns>
		Task<T?> GetByIdAsync<T>(int id)
            where T : class;

		/// <summary>
		/// Method to retrieve all entities of type T as no tracking entities
		/// </summary>
		/// <typeparam name="T">Type of the target entity</typeparam>
		/// <returns>Queryable expression tree</returns>
		IQueryable<T> AllAsReadOnly<T>()
			where T : class;
	}
}
