using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeisureStarLevel2.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Welcome to LeisureStarLevel2!";

			return View();
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
