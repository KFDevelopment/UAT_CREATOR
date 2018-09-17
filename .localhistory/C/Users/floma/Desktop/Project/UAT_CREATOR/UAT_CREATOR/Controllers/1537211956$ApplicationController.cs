using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UAT_CREATOR.DAL;

namespace UAT_CREATOR.Controllers
{
    public class ApplicationController : Controller
    {

        protected UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Application
        public ActionResult Index()
        {


            return View(unitOfWork.ApplicationRepository.ToList());
        }
    }
}