using System;
using System.Data.Entity;

namespace PowerMonitoring.DataAccess.Componenets
{
    public class Repository<TContext,T> : IRepository<T> where TContext : DbContext, new() where T:class 
    {
        public TContext Context { get; private set; }

        public Repository()
        {
            Context = new TContext();
        }

        public Repository(string connectionString)
        {
            Context = Activator.CreateInstance(typeof (TContext), connectionString) as TContext;
        }

        public T Insert(T item, bool saveNow)
        {
            return Operation(item, EntityState.Added, saveNow);
        }

        public T Update(T item, bool saveNow)
        {
            return Operation(item, EntityState.Modified, saveNow);
        }

        public T Delete(T item, bool saveNow) 
        {
            return Operation(item, EntityState.Deleted, saveNow);
        }

        private T Operation(T item, EntityState entityState, bool saveNow)
        {
            Context.Entry(item).State = entityState;
            if (saveNow)
            {
                Context.SaveChanges();
            }
            return item;
        }

        public bool Save()
        {
            Context.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}