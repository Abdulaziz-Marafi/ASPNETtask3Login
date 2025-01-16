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
                var user = db.Users.Where(u => u.Username == model.Username);
                if (user.Any())
                {
                    ModelState.AddModelError("Username", "Username is already taken");
                    ViewBag.Roles = new SelectList(db.Roles, "RoleId", "RoleName");

                    return View(model);
                }
                // Check if email is taken
                user = db.Users.Where(u => u.Email == model.Email);
                if (user.Any())
                {
                    ModelState.AddModelError("Email", "Email is already taken");
                    ViewBag.Roles = new SelectList(db.Roles, "RoleId", "RoleName");

                    return View(model);
                }
                var user1 = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    Email = model.Email,
                    RoleId = model.RoleId
                };
                db.Users.Add(user1);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            ViewBag.Roles = new SelectList(db.Roles, "RoleId", "RoleName");
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
                var user = db.Users.Where(u => u.Username == model.Username && u.Password == model.Password);
                if (user.Any())
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
