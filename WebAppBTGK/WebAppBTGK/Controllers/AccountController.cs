using Application;
using DataAccess;
using Domain;
using Lap.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAppBTGK.Models;

namespace WebAppBTGK.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly BookContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private static List<User> users = new List<User>();
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            BookContext context, IUnitOfWork unitOfWork)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Validate the user credentials
            var user = users.FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            // If login is successful, redirect to the home page or another page
            return RedirectToAction("Index", "Home");
        }

        private bool ValidateUser(string userName, string password)
        {
            // Replace this with your actual user validation logic
            return userName == "admin" && password == "123";
        }



        // GET: Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Save the user details to the list (or database)
            users.Add(new User
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Password = model.Password,
                Email = model.Email
            });

            // Redirect to the login page after successful registration
            return RedirectToAction("Login", "Account");
        }

        private bool RegisterUser(RegisterVM model)
        {
            // Replace this with your actual user registration logic
            // For example, save the user details to a database
            return true;
        }


    }
}
