using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeisureStarLevel2.Models;
using ExoGraph;

namespace LeisureStarLevel2.Controllers
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
