using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeisureStar.Models;
using ExoGraph;

namespace LeisureStar.Controllers
{
	public class GameController : Controller
	{
		/// <summary>
		/// /Game
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			ViewBag.Title = "Games";
			return View(Game.All);
		}

		public ActionResult Edit(string id)
		{
			ViewBag.Title = "Edit Game";
			return View(GraphContext.Create<Game>(id));
		}

		public ActionResult ViewResults(string id)
		{
			ViewBag.Title = "Game Results";
			return View(GraphContext.Create<Game>(id));
		}

		public ActionResult Play(string id)
		{
			ViewBag.Title = "Play Game";
			return View(GraphContext.Create<Game>(id));
		}

	}
}
