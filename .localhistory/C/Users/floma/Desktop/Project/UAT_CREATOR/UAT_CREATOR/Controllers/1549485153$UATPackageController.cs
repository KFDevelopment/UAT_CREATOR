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
                try {
                    fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                } catch (Exception e) {

                    error +=( " /// " + e.Message);
                }
                
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories()) {
                try {
                    DirectoryInfo nextTargetSubDir =
                   target.CreateSubdirectory(diSourceSubDir.Name);
                    error += CopyAll(diSourceSubDir, nextTargetSubDir);
                } catch (Exception e) {

                    error += (" /// " + e.Message);
                }
               
                
            }
            return error;
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
                DirectoryInfo diTarget = new DirectoryInfo(DestinationFolder);
                string pathDirectory = migration.DateUATPackage.Year + "" + migration.DateUATPackage.Month + "" + migration.DateUATPackage.Day + "" + migration.DateUATPackage.Hour + "" + migration.DateUATPackage.Minute;
                int i = 1;
                var tmp = diTarget.GetDirectories().Select(d => d.Name);
                if (tmp.Contains(pathDirectory)) throw new Exception("the folder " + pathDirectory + " already exist in the destination folder " + DestinationFolder);

                diTarget.CreateSubdirectory(pathDirectory);

                Copy(releaseFolder, releaseFolder + "/" + pathDirectory);



                DirectoryInfo folder = new DirectoryInfo(releaseFolder + "/" + pathDirectory);
                folder.GetFiles().FirstOrDefault(d => d.Name == FileToExclude).Delete();



            } catch (Exception e) {

                migration.Error += (" ///// " + e.Message);
            }



            return RedirectToAction(nameof(Index));
        }
    }
}