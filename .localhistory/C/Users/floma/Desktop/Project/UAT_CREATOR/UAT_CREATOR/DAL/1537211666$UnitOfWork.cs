using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UAT_CREATOR.Model;

namespace UAT_CREATOR.DAL {
    public class UnitOfWork : IDisposable {

        private UAT_CREATOREntities context = new UAT_CREATOREntities();



        public void Dispose() {
            context.Dispose();
        }
    }
}