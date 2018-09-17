using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using UAT_CREATOR.Model;

namespace UAT_CREATOR.DAL {
    public abstract class GenericRepository<T> where T : class {


        protected UAT_CREATOREntities context;
        protected DbSet<T> dbset;

        public GenericRepository() {
            dbset = context.Set<T>();
        }


        public virtual T Find(object id) {
            return dbset.Find(id);
        }
        public virtual void Add(T Entity) {
             dbset.Add(Entity);
        }
        public virtual void Add(List<T> Entities) {
             dbset.AddRange(Entities);
        }
        public virtual void Remove(T Entity) {
            dbset.Remove(Entity);
        }
        public virtual void Update(T Entity) {
            context.Entry<T>(Entity).State = EntityState.Modified;
           
        }
       
        public virtual void Update(List<T> Entities) {
            Entities.ForEach(d => Update(d));
        }
        public virtual void Remove(List<T> Entities) {
            dbset.RemoveRange(Entities);
        }
        public virtual List<T> ToList() {
            return dbset.ToList();
        }

        public virtual T FirstOrDefault(Expression<Func<T,bool>> predicate) {
            return dbset.FirstOrDefault(predicate);
        }
        public virtual T First(Expression<Func<T, bool>> predicate) {
            return dbset.First(predicate);
        }
        public virtual IQueryable<T> OrderBy(Expression<Func<T, bool>> predicate) {
            return dbset.OrderBy(predicate);
        }



    }
}