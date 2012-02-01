using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeisureStar.Models;

namespace LeisureStar.Controllers
{
	public class HomeController : Controller
	{
		[AllowAnonymous]
		public ActionResult Index()
		{
			ViewBag.Title = "Recent Games";
			return View(Game.All);
		}
	}
}
