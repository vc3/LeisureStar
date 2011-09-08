using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeisureStar.Models;

namespace LeisureStar.Controllers
{
	public class GameController : Controller
	{
		//
		// GET: /Game/
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Edit(string id)
		{
			ViewData["Id"] = id;
			return View();
		}

		public ActionResult ViewResults(string id)
		{
			ViewData["Id"] = id;
			return View();
		}

		public ActionResult Play(string id)
		{
			ViewData["Id"] = id;
			return View();
		}

	}
}
