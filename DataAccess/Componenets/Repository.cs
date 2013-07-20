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

        public T GetById(int id)
        {
            Type typeOfPoco = GetTypeOfPoco();
            return ConvertToDto(Context.Set(typeOfPoco).Find(id)) as T;
        }

        private T Operation(T item, EntityState entityState, bool saveNow)
        {
            object poco = ConvertToPoco(item);

            Context.Entry(poco).State = entityState;
            if (saveNow)
            {
                Context.SaveChanges();
            }

            return ConvertToDto(poco) as T;
        }

        public virtual object ConvertToPoco(T dto)
        {
            return dto;
        }

        public virtual object ConvertToDto(object entity)
        {
            return entity;
        }

        public virtual Type GetTypeOfPoco()
        {
            return typeof (T);
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