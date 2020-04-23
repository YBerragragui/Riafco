using System;
using System.Collections.Generic;


namespace Riafco.Dal.Dataflex.Pro.Interface
{
    /// <summary>
    /// The IGenericRepository interface.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The generic delete method by identifier
        /// </summary>
        /// <param name="id">identifier</param>
        void Delete(object id);

        /// <summary>
        /// The generic delete method
        /// </summary>
        /// <param name="entityToDelete">entit y To Delete</param>
        void Delete(TEntity entityToDelete);

        /// <summary>
        /// Detach Object
        /// </summary>
        /// <param name="entityToDetach">entity To Detach</param>
        void DetachObject(TEntity entityToDetach);

        /// <summary>
        /// The generic get method
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="orderBy">orderBy</param>
        /// <param name="includeProperties">include Properties</param>
        /// <returns>IEnumerable</returns>
        IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<System.Linq.IQueryable<TEntity>, System.Linq.IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        /// <summary>
        /// The generic get by id method
        /// </summary>
        /// <param name="id">identifier</param>
        /// <returns>TEntity</returns>
        TEntity GetById(object id);

        /// <summary>
        /// The generic insert method
        /// </summary>
        /// <param name="entity">TEntity</param>
        void Insert(TEntity entity);

        /// <summary>
        /// The generic update method
        /// </summary>
        /// <param name="entityToUpdate">entity To Update</param>
        void Update(TEntity entityToUpdate);

        /// <summary>
        /// Gets items by query
        /// </summary>
        /// <param name="sqlQuery">query</param>
        /// <param name="parameters">params of query</param>
        /// <returns>Returm items</returns>
        IEnumerable<TEntity> GetItemsByQuery(string sqlQuery, params object[] parameters);

        /// <summary>
        /// Update List of entities
        /// </summary>
        /// <param name="entitiesToUpdate">Entities to update</param>
        void Update(IEnumerable<TEntity> entitiesToUpdate);

        /// <summary>
        /// Delete List of entities
        /// </summary>
        /// <param name="entityTiesToDelete">Entities to delete</param>
        void Delete(IEnumerable<TEntity> entityTiesToDelete);

        /// <summary>
        /// Insert List of entities
        /// </summary>
        /// <param name="entitiesToInsert">Entities to update</param>
        void Insert(IEnumerable<TEntity> entitiesToInsert);

        /// <summary>
        /// Gets items by query
        /// </summary>
        /// <param name="sqlQuery">query</param>
        /// <param name="parameters">params of query</param>
        /// <returns>Gets items count by query</returns>
        IEnumerable<T> GetItemsCountByQuery<T>(string sqlQuery, params object[] parameters);
    }
}
