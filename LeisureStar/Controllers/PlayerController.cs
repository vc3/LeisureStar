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
		/// <summary>
		/// /Player
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			ViewBag.Title = "Players";
			return View(Player.All);
		}

		/// <summary>
		/// /Player/Edit/#
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ActionResult Edit(string id)
		{
			ViewBag.Title = "Edit Player";
			return View(GraphContext.Create<Player>(id));
		}
	}
}
