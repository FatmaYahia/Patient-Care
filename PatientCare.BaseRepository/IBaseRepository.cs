using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PatientCare.BaseRepository
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll();

        List<T> GetAll(Expression<Func<T, bool>> expression);

        bool Any(Expression<Func<T, bool>> expression);

        T GetByID(int id);

        bool Any();

        T CreateEntity(T entity);

        void UpdateEntity(T entity);

        void DeleteEntity(List<T> entities);

        void DeleteEntity(T entity);

        int Save();
    }
}
