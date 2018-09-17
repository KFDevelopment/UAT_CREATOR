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



        public ActionResult PublishPackageToUATFolder(int ApplicationId,string DestinationFolder) {



            Application application = context.ApplicationRepository.Find(ApplicationId);




            return RedirectToAction(nameof(Index));
        }
    }
}