using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AdventureWorks.Mobile.Services._002_Infra.EF;

namespace AdventureWorks.Mobile.Services._002_Infra
{
    public interface IQueryableUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Returns a IDbSet instance for access to entities of the given type in the context,
        /// the ObjectStateManager, and the underlying store.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        DbSet<TEntity> CreateSet<TEntity>()
            where TEntity : class;

        /// <summary>
        /// Gets a System.Data.Entity.Infrastructure.DbEntityEntry 
        /// object for the given entity providing access to information about the entity 
        /// and the ability to perform actions on the entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of tthe entity.</typeparam>
        /// <param name="entity">The entity.</param>
        DbEntityEntry<TEntity> GetEntry<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// Apply current values in <paramref name="original"/>
        /// </summary>
        /// <typeparam name="TEntity">The type of entity.</typeparam>
        /// <param name="original">The original entity.</param>
        /// <param name="current">The current entity.</param>
        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current)
            where TEntity : class;
    }
}