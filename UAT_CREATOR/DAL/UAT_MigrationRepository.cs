using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UAT_CREATOR.Model;

namespace UAT_CREATOR.DAL {
    public class UAT_MigrationRepository:GenericRepository<UAT_Migration> {

        public UAT_MigrationRepository(UAT_CREATOREntities context) : base(context) { }
    }
}