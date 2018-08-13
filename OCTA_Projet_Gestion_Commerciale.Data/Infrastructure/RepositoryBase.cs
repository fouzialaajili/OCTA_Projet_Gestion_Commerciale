using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;





using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Infrastructure
{
    
        public abstract class RepositoryBase<T> where T : class
        {
            #region Properties
            private StoreEntities dataContext;
            private readonly IDbSet<T> dbSet;

            protected IDbFactory DbFactory
            {
                get;
                private set;
            }

            protected StoreEntities DbContext
            {
                get { return dataContext ?? (dataContext = DbFactory.Init()); }
            }
            #endregion

            protected RepositoryBase(IDbFactory dbFactory)
            {
                DbFactory = dbFactory;
                dbSet = DbContext.Set<T>();
            }

            #region Implementation
            /// <summary>
            /// Detach Object
            /// </summary>
            /// <param name="entityToDetach">entity To Detach</param>
            public virtual void DetachObject(T entity)
            {
                dataContext.Entry(entity).State = EntityState.Detached;
            }
            public virtual void Add(T entity)
            {
                dbSet.Add(entity);
            }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Update(object idSource, T entity)
        {
            T entityToUpdate = dbSet.Find(idSource);
            dataContext.Entry(entityToUpdate).CurrentValues.SetValues(entity);
        }
        public virtual void Delete(object idSource, T entity)
        {
            //dbSet.Attach(entity);
            //dbSet.Remove(entity);
            T entityToDelete = dbSet.Find(idSource);
            if (dataContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);

            }
            dataContext.Entry(entityToDelete).State = EntityState.Deleted;


            //  dbSet.Remove(entityToDelete);

        }
        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

                    public virtual void Delete(Expression<Func<T, bool>> where)
                    {
                        IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
                        foreach (T obj in objects)
                            dbSet.Remove(obj);
                    }

                    public virtual T GetById(int id)
                    {
                        return dbSet.Find(id);
                    }

                    public virtual IEnumerable<T> GetAll()
                    {
                        return dbSet.ToList();
                    }

                    public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
                    {
                        return dbSet.Where(where).ToList();
                    }

                    public T Get(Expression<Func<T, bool>> where)
                    {
                        return dbSet.Where(where).FirstOrDefault<T>();
                    }

                    #endregion
                  
            #region Properties
            private StoreEntities dataContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected StoreEntities DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        #endregion
    }
}