using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UAT_CREATOR.Controllers {
    public class HomeController : Controller {

        protected UnitOfWork context = new UnitOfWork();

        public ActionResult Index() {
            return View();
        }

        public ActionResult _NewUAT() {
            return PartialView()
        }
       
    }
}