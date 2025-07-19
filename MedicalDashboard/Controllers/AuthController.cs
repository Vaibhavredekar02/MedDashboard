using MedicalDashboard.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

public class AuthController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: Auth/Register
    public ActionResult Register()
    {
        return View();
    }

    // POST: Auth/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
            // Check for duplicate email
            if (db.Users.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "Email already exists.");
                return View(user);
            }

            user.PasswordHash = HashPassword(user.PasswordHash);
            user.CreatedAt = DateTime.Now;
            db.Users.Add(user);
            db.SaveChanges();

            TempData["Success"] = "Registration successful! Please login.";
            return RedirectToAction("Login");
        }

        return View(user);
    }

    // GET: Auth/Login
    public ActionResult Login()
    {
        return View();
    }

    // POST: Auth/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(string email, string password)
    {
        var passwordHash = HashPassword(password);
        var user = db.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == passwordHash);

        if (user != null)
        {
            // Set session
            Session["UserId"] = user.UserId;
            Session["FullName"] = user.FullName;
            return RedirectToAction("MedicalDashboard", "Dashboard");
        }

        ViewBag.Error = "Invalid email or password.";
        return View();
    }

   

    // Helper: Hash password
    private string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }



    public ActionResult ForgotPassword()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult ForgotPassword(string email)
    {
        var user = db.Users.FirstOrDefault(u => u.Email == email);

        if (user == null)
        {
            ViewBag.Error = "Email not found.";
            return View();
        }

        // Show form to reset password
        TempData["ResetEmail"] = email;
        return RedirectToAction("ResetPassword");
    }


    public ActionResult ResetPassword()
    {
        if (TempData["ResetEmail"] == null)
            return RedirectToAction("ForgotPassword");

        ViewBag.Email = TempData["ResetEmail"];
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult ResetPassword(string email, string newPassword)
    {
        var user = db.Users.FirstOrDefault(u => u.Email == email);

        if (user != null)
        {
            user.PasswordHash = HashPassword(newPassword);
            db.SaveChanges();

            TempData["Success"] = "Password reset successful. Please login.";
            return RedirectToAction("Login");
        }

        ViewBag.Error = "Error resetting password.";
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Logout()
    {
        Session.Clear();
        Session.Abandon();

        // Clear authentication cookie (optional, but ensures logout)
        Response.Cookies.Clear();
        return RedirectToAction("Login", "Auth");
    }

}
