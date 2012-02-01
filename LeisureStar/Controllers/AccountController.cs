using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ExoGraph;
using LeisureStar.Models;

namespace LeisureStar.Controllers
{
    public class AccountController : Controller
    {
		[AllowAnonymous]
        public ActionResult LogOn()
        {
			ViewBag.Title = "Login";
			return View(GraphContext.Create<Account>());
        }

		[HttpPost]
		[AllowAnonymous]
		public ActionResult LogOn(Account model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				if (Account.ValidateUser(model.UserName, Encryption.Encrypt(model.Password)))
				{
					FormsAuthentication.SetAuthCookie(model.UserName, true);
					if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
						&& !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
					{
						return Redirect(returnUrl);
					}
					else
					{
						return RedirectToAction("Index", "Home");
					}
				}
				else
				{
					ModelState.AddModelError("", "The user name or password provided is incorrect.");
				}
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		[AllowAnonymous]
		public ActionResult LogOff()
		{
			FormsAuthentication.SignOut();

			return RedirectToAction("Index", "Home");
		}
    }
}
