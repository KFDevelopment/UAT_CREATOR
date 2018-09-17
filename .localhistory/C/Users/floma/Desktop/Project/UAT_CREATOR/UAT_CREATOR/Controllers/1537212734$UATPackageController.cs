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

        public static void Copy(string sourceDirectory, string targetDirectory) {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target) {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles()) {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories()) {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
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