using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using İnsanKaynaklarıPT.Models;
using İnsanKaynaklarıPT.DbContextS;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace İnsanKaynaklarıPT.Controllers
{
    public class AccessController : Controller
    {
        private readonly DbContextQ  dbContextQ;
        public AccessController(DbContextQ context)
        {
            dbContextQ = context;
        }
        public IActionResult Login()
        {
            ClaimsPrincipal principal = HttpContext.User;
            if (principal.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User  user)
        {
            User user2 = dbContextQ.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password && u.İsActtive==true);
			if (user2 !=null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Email),
                    new Claim("OtherProperties","Example Role"),
                };
                ClaimsIdentity identity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = user.KeepLogged,
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity), properties);
                return RedirectToAction("Index", "Home");
            }
            ViewData["ValidateMessage"] = "Kullanıcı Bulunamadı";
            return View();
        }
    }
}
