using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace LeaveEmployeeManager.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        public string? ReturnUrl { get; set; }
        public void OnGet(string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            //track last page request
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            //track last page request
            ReturnUrl = returnUrl;

            //Real database call to check if username and password are correct:ToDo
            if(Input.Mail == "admin@test.com" && Input.Password == "password")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,Input.Mail),
                    new Claim(ClaimTypes.Name,"Admin_"+Input.Mail),
                    new Claim(ClaimTypes.Role,"Admin"),


                };

                var identityUser = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identityUser);

                //Now Log in
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal,
                    new AuthenticationProperties { IsPersistent = Input.RememberMe});

                //Security feature
                return LocalRedirect(ReturnUrl);
            }
            else
            {
                return Unauthorized();
            }
        }
    }



    public class InputModel
    {
        [Required]
        [EmailAddress]
        public string Mail { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name ="Remember me?")]
        public bool RememberMe { get; set; }
    }
}
