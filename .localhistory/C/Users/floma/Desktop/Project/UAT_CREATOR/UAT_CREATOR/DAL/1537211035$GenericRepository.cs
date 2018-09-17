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

        public virtual List<T> ToList() {
            return dbset.ToList();
        }

        public virtual T FirstOrDefault(Expression<Func<T,bool>> predicate) {
            return dbset.FirstOrDefault(predicate);
        }
        public virtual T First(Expression<Func<T, bool>> predicate) {
            return dbset.First(predicate);
        }

    }
}