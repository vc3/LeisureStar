using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeisureStar.Models;
using ExoModel;

namespace LeisureStar.Controllers
{
	public class TeamController : Controller
	{
		/// <summary>
		/// /Team
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			ViewBag.Title = "Teams";
			return View(Team.All);
		}

		/// <summary>
		/// /Team/Edit/#
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ActionResult Edit(string id)
		{
			ViewBag.Title = "Edit Team";
			return View(ModelContext.Create<Team>(id));
		}
	}
}
