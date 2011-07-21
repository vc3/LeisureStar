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
			LeisureStarDataContext context = LeisureStarDataContext.Current;
			var games = from p in context.Games
						  select p;
			return View(games);
        }

    }
}
