using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UAT_CREATOR.DAL;

namespace UAT_CREATOR.Controllers {
    public class HomeController : Controller {

        protected UnitOfWork context = new UnitOfWork();

        public ActionResult Index() {
            return View();
        }

        public ActionResult _NewUAT() {
            return PartialView(context.ApplicationRepository.ToList().OrderBy(d => d.Label).ToList());
        }
       
    }
}