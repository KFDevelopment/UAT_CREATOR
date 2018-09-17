using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UAT_CREATOR.DAL;
using UAT_CREATOR.Model;

namespace UAT_CREATOR.Controllers
{
    public class UATPackageController : Controller
    {

        protected UnitOfWork context = new UnitOfWork();
        // GET: UATPackage
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult PublishPackageToUATFolder(int ApplicationId, string DestinationFolder,string releaseFolder) {



            Application application = context.ApplicationRepository.Find(ApplicationId);


            UAT_Migration migration = new UAT_Migration {
                ApplicationId = application.Id,
                Application = application,
                DateUATPackage = DateTime.Now,
            };
            string FileToExclude = "web.config";
            try {






            } catch (Exception e) {

                migration.Error += (" ///// " + e.Message);
            }



            return RedirectToAction(nameof(Index));
        }
    }
}