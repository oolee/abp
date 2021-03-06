﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace Volo.Abp.Account.Web.Areas.Account.Controllers
{
    [Area("Account")]
    public class LogoutController : AbpController
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LogoutController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        //todo@alper: this method can be moved to AccountController like "account/logout"
        public async Task<IActionResult> Index(string returnUrl = null)
        {
            await _signInManager.SignOutAsync().ConfigureAwait(false);

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }

            return RedirectToPage("/Account/Login");
        }
    }
}
