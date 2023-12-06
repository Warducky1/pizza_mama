using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Pizza_mama.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public bool _DisplayInvalidAccountMessage;
        IConfiguration _configuration;
        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult OnGet()
        {
            if(this.HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("Admin/Pizzas");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(string username, string password, string ReturnUrl)
        {
            var authSection = _configuration.GetSection("Auth");

            string adminLogin = authSection["AdminLogin"];
            string adminPassword = authSection["AdminPassword"];

            if (username.ToLower() == adminLogin && password == adminPassword)
            {
                _DisplayInvalidAccountMessage = false;
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, username)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return Redirect(ReturnUrl == null ? "/Admin/Pizzas" : ReturnUrl);
            }
            
            _DisplayInvalidAccountMessage = true;
            return Page();
        }

        public async Task<IActionResult> OnGetLogout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/Admin/Index");
        }

    }
}
