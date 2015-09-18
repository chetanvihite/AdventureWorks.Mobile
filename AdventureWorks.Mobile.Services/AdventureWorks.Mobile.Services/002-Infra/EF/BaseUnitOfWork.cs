using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace AdventureWorks.Mobile.Services._002_Infra
{
    public class BaseUnitOfWork : DbContext, IQueryableUnitOfWork
    {
        public BaseUnitOfWork(string name)
            : base(name)
        {
            Configuration.LazyLoadingEnabled = true;
        }

        #region IQueryableUnitOfWork Members

        public DbSet<TModel> CreateSet<TModel>()
            where TModel : class
        {
            return base.Set<TModel>();
        }

        public DbEntityEntry<TModel> GetEntry<TModel>(TModel entity)
            where TModel : class
        {
            return base.Entry<TModel>(entity);
        }

        public void ApplyCurrentValues<TModel>(TModel original, TModel current)
            where TModel : class
        {
            //if it is not attached, attach original and set current values
            base.Entry<TModel>(original).CurrentValues.SetValues(current);
        }

        #endregion

        #region IUnitOfWork

        public void Commit()
        {
            base.SaveChanges();
        }

        public void Rollback()
        {
            // set all entities in change tracker 
            // as 'unchanged state'
            base.ChangeTracker.Entries()
                .ToList()
                .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        #endregion

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return base.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        public IEnumerable<TModel> ExecuteQuery<TModel>(string sqlQuery, params object[] parameters)
        {
            return base.Database.SqlQuery<TModel>(sqlQuery, parameters);
        }

    }
}
