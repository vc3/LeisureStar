using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeisureStarLevel2.Models;

namespace LeisureStarLevel2.Controllers
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
