using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeisureStar.Models;
using ExoGraph;

namespace LeisureStar.Controllers
{
	public class PlayerController : Controller
	{
		//
		// GET: /Player/

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Edit(string id)
		{
			ViewData["Id"] = id;
			return View();
		}
	}
}
