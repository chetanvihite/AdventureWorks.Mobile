using AdventureWorks.Mobile.Services._001_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AdventureWorks.Mobile.Services._002_Infra.EF
{

    /// <summary>
    /// Base interface for implement a "Repository Pattern", for more information about this pattern see:
    /// http://martinfowler.com/eaaCatalog/repository.html or:
    /// http://blogs.msdn.com/adonet/archive/2009/06/16/using-repository-and-unit-of-work-patterns-with-entity-framework-4-0.aspx
    /// </summary>
    /// <remarks>
    /// This interface allows us to ensure PI principle within the domain model
    /// </remarks>
    public interface IRepository<TEntity> : IDisposable
         where TEntity : BaseEntity
    {
        #region Properties
        /// <summary>
        /// Gets the unit of work in this repository
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        #endregion

        /// <summary>
        /// Adds entity into repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Sets entity as modified.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Delete entity from repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Sets modified entity into the repository. 
        /// When calling Commit() method in UnitOfWork 
        /// these changes will be saved into the storage.
        /// </summary>
        /// <param name="persisted">The persisted entity.</param>
        /// <param name="current">The current entity.</param>
        void Merge(TEntity persisted, TEntity current);

        /// <summary>
        /// Gets element by entity key.
        /// </summary>
        /// <param name="id">Entity key value.</param>
        /// <returns></returns>
        TEntity FindById(Guid id);

        /// <summary>
        /// Gets all entities of type TEntity in repository.
        /// </summary>
        /// <returns>List of selected elements.</returns>
        IEnumerable<TEntity> FindAll();

        /// <summary>
        /// Gets all entities of type TEntity that matching a predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>List of selected elements.</returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Gets all elements of type TEntity that are into the selected page.
        /// </summary>
        /// <param name="pageIndex">Page index.</param>
        /// <param name="pageCount">Number of elements in each page.</param>
        /// <param name="orderByPredicate">The order by predicate.</param>
        /// <param name="ascending">Specify if order is ascending.</param>
        /// <returns>List of selected elements.</returns>
        IEnumerable<TEntity> Find<TKProperty>(
            int pageIndex,
            int pageCount,
            Expression<Func<TEntity, TKProperty>> orderByPredicate,
            bool ascending);
    }
}