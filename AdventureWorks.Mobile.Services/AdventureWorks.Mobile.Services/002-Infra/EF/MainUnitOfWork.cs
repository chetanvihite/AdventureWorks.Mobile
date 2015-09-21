using AdventureWorks.Mobile.Services._001_Domain;
using AdventureWorks.Mobile.Services._002_Infra.EF.Mappings;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;


namespace AdventureWorks.Mobile.Services._002_Infra
{
    public class MainUnitOfWork : DbContext, IQueryableUnitOfWork
    {
        public MainUnitOfWork(string name)
            : base(name)
        {
            this.Configuration.LazyLoadingEnabled = true;
            //this.Configuration.AutoDetectChangesEnabled = false;
        }

        #region IDbSet Members
        
        public IDbSet<Order> Orders { get; set; }
     
        #endregion

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

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            Database.SetInitializer<MainUnitOfWork>(null);

            modelBuilder.Configurations.Add(new OrdersMap());
            
        }
    }
}
