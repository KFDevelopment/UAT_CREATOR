using System;
using System.Collections.Generic;
using System.IO;
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

        public static string Copy(string sourceDirectory, string targetDirectory) {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            return CopyAll(diSource, diTarget);
        }
       
        public static string CopyAll(DirectoryInfo source, DirectoryInfo target) {
            string error = string.Empty;
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles()) {
                
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories()) {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                error+=CopyAll(diSourceSubDir, nextTargetSubDir);
            }
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