using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PatientCare.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PatientCare.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext DataBase;

        public BaseRepository(DataContext DataBase)
        {
            this.DataBase = DataBase;
        }

        public bool Any()
        {
            return DataBase.Set<T>().Any();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return DataBase.Set<T>().Where(expression).Any();
        }

        public T CreateEntity(T entity)
        {
            //  EntityEntry<T> to return the created entity with it's id
            EntityEntry<T> Entity = DataBase.Set<T>().Add(entity);
            return Entity.Entity;
        }

        public void DeleteEntity(List<T> entities)
        {
            DataBase.Set<T>().RemoveRange(entities);
        }

        public void DeleteEntity(T entity)
        {
            DataBase.Set<T>().RemoveRange(entity);
        }

        public List<T> GetAll()
        {
            return DataBase.Set<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return DataBase.Set<T>().Where(expression).ToList();
        }

        public T GetByID(int id)
        {
            return DataBase.Set<T>().Find(id);
        }

        public int Save()
        {
            return DataBase.SaveChanges();
        }

        public void UpdateEntity(T entity)
        {
            DataBase.Entry(entity).State = EntityState.Modified;
        }
    }
}
