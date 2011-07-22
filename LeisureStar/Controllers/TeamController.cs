using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeisureStar.Models;
using ExoGraph;

namespace LeisureStar.Controllers
{
	public class TeamController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Edit(string id)
		{
			ViewData["Team"] = GraphContext.Create<Team>(id);
			return View();
		}
    }
}
