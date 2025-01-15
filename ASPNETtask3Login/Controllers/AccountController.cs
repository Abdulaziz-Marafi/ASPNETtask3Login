using ASPNETtask3Login.Data;
using ASPNETtask3Login.Models;
using ASPNETtask3Login.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ASPNETtask3Login.Controllers
{
    public class AccountController : Controller
    {
        private ASPLoginDbContext db;
        public AccountController(ASPLoginDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Roles = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if username is taken
                var user = db.Users.FirstOrDefault(u => u.Username == model.Username);
                if (user != null)
                {
                    ModelState.AddModelError("Username", "Username is already taken");
                    return View(model);
                }
                // Check if email is taken
                user = db.Users.FirstOrDefault(u => u.Email == model.Email);
                if (user != null)
                {
                    ModelState.AddModelError("Email", "Email is already taken");
                    return View(model);
                }
                user = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    Email = model.Email,
                    RoleId = model.RoleId
                };
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.SingleOrDefault(u => u.Username == model.Username && u.Password == model.Password);
                if (user != null)
                {
                    return RedirectToAction("Display");
                }
                ModelState.AddModelError("Password", "Username or Password is incorrect");
            }
            return View(model);
        }

        public IActionResult Display()
        {
            return View(db.Users);
        }
    }
}
