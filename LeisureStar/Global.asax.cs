using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ExoGraph;
using System.Reflection;
using ExoGraph.EntityFramework;
using LeisureStar.Models;

namespace LeisureStar
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);

		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);

			//System.Diagnostics.Debugger.Launch();
			new GraphContextProvider().CreateContext += (source, args) =>
			{
				Assembly coreAssembly = typeof(MvcApplication).Assembly;
				args.Context = new GraphContext(new EntityFrameworkGraphTypeProvider(() => new LeisureStarDataContext()));

				ExoRule.Rule.RegisterRules(coreAssembly);
			};

			ExoWeb.ExoWeb.Adapter = new ExoWeb.DataAnnotations.ServiceAdapter();
		}
	}
}