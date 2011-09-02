using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeisureStar.Models;

namespace LeisureStar.Controllers
{
    public class PlayerController : Controller
    {
        //
        // GET: /Player/

        public ActionResult Index()
        {
			LeisureStarDataContext context = LeisureStarDataContext.Current;
			var players = from p in context.Players
						  select p;
            return View(players);
        }

    }
}
