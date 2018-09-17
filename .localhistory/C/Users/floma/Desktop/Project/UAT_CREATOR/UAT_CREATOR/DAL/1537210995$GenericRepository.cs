using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UAT_CREATOR.Model;

namespace UAT_CREATOR.DAL {
    public abstract class GenericRepository<T> where T : class {


        protected UAT_CREATOREntities context;
        protected DbSet<T> dbset;

        protected GenericRepository() {
            dbset = context.Set<T>();
        }
    }
}