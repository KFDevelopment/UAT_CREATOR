using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UAT_CREATOR.Model;

namespace UAT_CREATOR.DAL {
    public class UnitOfWork : IDisposable {

        private UAT_CREATOREntities context = new UAT_CREATOREntities();

        private ApplicationRepository applicationRepository;
        private UAT_MigrationRepository uAT_MigrationRepository;
        private ConfigurationRepository configurationRepository;
        public UAT_MigrationRepository UAT_MigrationRepository {
            get {
                if (uAT_MigrationRepository == null) uAT_MigrationRepository = new UAT_MigrationRepository(context);
                return uAT_MigrationRepository;
            }
        }
        public ConfigurationRepository ConfigurationRepository {
            get {
                if (configurationRepository == null) configurationRepository = new ConfigurationRepository(context);
                return configurationRepository;
            }
        }
        public ApplicationRepository ApplicationRepository {
            get {
                if (applicationRepository == null) applicationRepository = new ApplicationRepository(context);
                return applicationRepository;
            }
        }


        public void Dispose() {
            context.Dispose();
        }
    }
}