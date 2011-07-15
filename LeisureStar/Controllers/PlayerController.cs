using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExoGraph;
using LeisureStar.Models;

namespace LeisureStar.Controllers
{
	public class PlayerController : Controller
	{
		public ActionResult List()
		{
			return View();
		}

		public ActionResult Edit(string id)
		{
			ViewData["Player"] = GraphContext.Create<Player>(id);
			return View();
		}
	}
}
