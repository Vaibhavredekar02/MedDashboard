using MedicalDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalDashboard.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult MedicalDashboard()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Auth");

            int userId = Convert.ToInt32(Session["UserId"]);
            var user = db.Users.Find(userId);

            var viewModel = new DashboardViewModel
            {
                User = user,
                UploadedFiles = db.MedicalFiles.Where(f => f.UserId == userId).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult UpdateProfile(User updatedUser, HttpPostedFileBase profilePic)
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            var user = db.Users.Find(userId);

            if (user != null)
            {
                user.Phone = updatedUser.Phone;
                user.Gender = updatedUser.Gender;

                if (profilePic != null && profilePic.ContentLength > 0)
                {
                    string fileName = System.IO.Path.GetFileName(profilePic.FileName);
                    string path = Server.MapPath("~/Content/ProfileUploads/" + fileName);
                    profilePic.SaveAs(path);
                    user.ProfileImagePath = "/Content/ProfileUploads/" + fileName;
                }

                db.SaveChanges();
            }

            return RedirectToAction("MedicalDashboard");
        }

        [HttpPost]
        public ActionResult UploadFile(string fileType, string fileName, HttpPostedFileBase file)
        {
            if (Session["UserId"] == null || file == null)
                return RedirectToAction("MedicalDashboard");

            int userId = Convert.ToInt32(Session["UserId"]);
            string uploadPath = Server.MapPath("~/Uploads/MedicalFiles/");
            System.IO.Directory.CreateDirectory(uploadPath);

            string fullPath = System.IO.Path.Combine(uploadPath, file.FileName);
            file.SaveAs(fullPath);

            db.MedicalFiles.Add(new MedicalFile
            {
                UserId = userId,
                FileName = fileName,
                FileType = fileType,
                FilePath = "/Uploads/MedicalFiles/" + file.FileName,
                UploadedAt = DateTime.Now
            });

            db.SaveChanges();

            return RedirectToAction("MedicalDashboard");
        }

        public ActionResult DeleteFile(int id)
        {
            var file = db.MedicalFiles.Find(id);
            if (file != null)
            {
                db.MedicalFiles.Remove(file);
                db.SaveChanges();
            }

            return RedirectToAction("MedicalDashboard");
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            // Force the browser not to cache any page
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        }


    }
}