using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UAT_CREATOR.Model;

namespace UAT_CREATOR.DAL {
    public class ApplicationRepository:GenericRepository<Application> {
        public ApplicationRepository(UAT_CREATOREntities context) : base(context) { }

    }
}