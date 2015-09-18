using AdventureWorks.Mobile.Services._001_Domain;
using AdventureWorks.Mobile.Services._002_Infra.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace AdventureWorks.Mobile.Services._002_Infra
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        #region Private Members
        private readonly IQueryableUnitOfWork _unitOfWork;
        #endregion

        #region Constructor

        /// <summary>
        /// Current a new instance of repository
        /// </summary>
        /// <param name="unitOfWork">Associated Unit Of Work</param>
        protected BaseRepository(IQueryableUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            _unitOfWork = unitOfWork;
        }

        #endregion
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetDbSet().FirstOrDefault(predicate);
        }
        #region IRepository Members

        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }


        public virtual void Add(TEntity entity)
        {
            if (entity != null)
            {
                GetDbSet().Add(entity); // add new item in this set.
            }
        }


        public virtual void Update(TEntity entity)
        {
            if (entity != null)
            {
                GetDbSet().Attach(entity);

                _unitOfWork.GetEntry(entity).State = EntityState.Modified;
            }
        }


        public virtual void Delete(TEntity entity)
        {
            if (entity != null)
            {
                if (_unitOfWork.GetEntry(entity).State == EntityState.Detached)
                {
                    GetDbSet().Attach(entity); // attach item if not exist.
                }

                GetDbSet().Remove(entity); // set as "removed".
            }
        }

        public void Merge(TEntity persisted, TEntity current)
        {
            _unitOfWork.ApplyCurrentValues(persisted, current);
        }

        public virtual TEntity FindById(Guid id)
        {
            return id != Guid.Empty ? GetDbSet().Find(id) : null;
        }

        public IEnumerable<TEntity> FindAll()
        {
            return GetDbSet();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return GetDbSet().Where(predicate);
        }

        public IEnumerable<TEntity> Find<TKProperty>(
            int pageIndex,
            int pageCount,
            Expression<Func<TEntity, TKProperty>> orderByPredicate,
            bool ascending)
        {
            var set = GetDbSet();
            return ascending
                       ? set.OrderBy(orderByPredicate)
                             .Skip(pageCount * pageIndex)
                             .Take(pageCount)
                       : set.OrderByDescending(orderByPredicate)
                             .Skip(pageCount * pageIndex)
                             .Take(pageCount);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (_unitOfWork != null)
            {
                _unitOfWork.Dispose();
            }
        }

        #endregion

        #region Private Methods

        private IDbSet<TEntity> GetDbSet()
        {
            return _unitOfWork.CreateSet<TEntity>();
        }

        #endregion
    }
}
