using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Riafco.Dal.Dataflex.Pro.Core
{
    public class GenericRepository<TEntity> : Interface.IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The internat context
        /// </summary>
        internal DbContext Context;

        /// <summary>
        /// The internal dbset
        /// </summary>
        internal DbSet<TEntity> DbSet;

        /// <summary>
        /// The generic repository constructor
        /// </summary>
        /// <param name="context">the context</param>
        public GenericRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// The generic get method
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="orderBy">orderBy</param>
        /// <param name="includeProperties">include Properties</param>
        /// <returns>IEnumerable></returns>
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return orderBy?.Invoke(query).ToList() ?? query.ToList();
        }

        /// <summary>
        /// The generic get by id method
        /// </summary>
        /// <param name="id">identifier</param>
        /// <returns>TEntity</returns>
        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// The generic insert method
        /// </summary>
        /// <param name="entity">TEntity</param>
        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        /// <summary>
        /// The generic delete method by identifier
        /// </summary>
        /// <param name="id">identifier</param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// The generic delete method
        /// </summary>
        /// <param name="entityToDelete">entit y To Delete</param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// Detach Object
        /// </summary>
        /// <param name="entityToDetach">entity To Detach</param>
        public virtual void DetachObject(TEntity entityToDetach)
        {
            Context.Entry(entityToDetach).State = EntityState.Detached;
        }

        /// <summary>
        /// The generic update method
        /// </summary>
        /// <param name="entityToUpdate">entity To Update</param>
        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <summary>
        /// Update List of entities
        /// </summary>
        /// <param name="entitiesToUpdate">Entities to update</param>
        public virtual void Update(IEnumerable<TEntity> entitiesToUpdate)
        {
            foreach (TEntity entity in entitiesToUpdate)
            {
                DbSet.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
        }

        /// <summary>
        /// Delete List of entities
        /// </summary>
        /// <param name="entityTiesToDelete">Entities to delete</param>
        public virtual void Delete(IEnumerable<TEntity> entityTiesToDelete)
        {
            foreach (TEntity entity in entityTiesToDelete)
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                {
                    DbSet.Attach(entity);
                }
                DbSet.Remove(entity);
            }
        }

        /// <summary>
        /// Insert List of entities
        /// </summary>
        /// <param name="entitiesToInsert">Entities to update</param>
        public virtual void Insert(IEnumerable<TEntity> entitiesToInsert)
        {
            DbSet.AddRange(entitiesToInsert);
        }

        /// <summary>
        /// Gets items by query
        /// </summary>
        /// <param name="sqlQuery">query</param>
        /// <param name="parameters">params of query</param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetItemsByQuery(string sqlQuery, params object[] parameters)
        {
            return Context.Database.SqlQuery<TEntity>(sqlQuery, parameters);
        }

        /// <summary>
        /// Gets items by query
        /// </summary>
        /// <param name="sqlQuery">query</param>
        /// <param name="parameters">params of query</param>
        /// <returns>Gets items count by query</returns>
        public virtual IEnumerable<T> GetItemsCountByQuery<T>(string sqlQuery, params object[] parameters)
        {
            return Context.Database.SqlQuery<T>(sqlQuery, parameters);
        }
    }
}
