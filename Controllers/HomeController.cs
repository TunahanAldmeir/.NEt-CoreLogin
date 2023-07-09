using İnsanKaynaklarıPT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using İnsanKaynaklarıPT.DbContextS;
using Microsoft.EntityFrameworkCore;
using DevExtreme.AspNet.Mvc;

namespace İnsanKaynaklarıPT.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContextQ dbContextQ;
        public HomeController(ILogger<HomeController> logger, DbContextQ context)
        {
            _logger = logger;
            dbContextQ = context;
        }
        public IActionResult Index()
        {
			string userEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var users = dbContextQ.Users.Include(u => u.Depart).ToList();

            ViewBag.Users = users;
            ViewBag.UserEmail = userEmail;
            ViewBag.Departs = dbContextQ.Departs.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.id == 0)
                {
                    // Adding a new user
                    dbContextQ.Users.Add(user);
                }
                else
                {
                    // Updating an existing user
                    var existingUser = dbContextQ.Users.Find(user.id);
                    if (existingUser == null)
                    {
                        return NotFound();
                    }

                    // Update the properties of the existing user
                    existingUser.Email = user.Email;
                    existingUser.Password = user.Password;
                    existingUser.İsActtive = user.İsActtive;
                }

                dbContextQ.SaveChanges();

                return Ok();
            }

            // If ModelState is not valid, return the validation errors
            return BadRequest(ModelState);
        }

        public IActionResult Privacy()
        {
            return View();
        }
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login", "Access");
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}