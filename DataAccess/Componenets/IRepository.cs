using System;

namespace PowerMonitoring.DataAccess.Componenets
{
    internal interface IRepository<T> : IDisposable where T : class
    {
        T Insert(T item, bool saveNow);
        T Update(T item, bool saveNow);
        T Delete(T item, bool saveNow);
        bool Save();
    }
}
