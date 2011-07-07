using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using WatiN.Core;
using WatiN.Core.Constraints;
using Find = VC3.AutomatedTesting.Testables.WebUI.Find;
using Page = VC3.AutomatedTesting.Testables.WebUI.Page;
using WatiN.Core.Actions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VC3.AutomatedTesting.Testables.WebUI;
using VC3.AutomatedTesting;

namespace LeisureStar.Tests.Pages
{
	public class ExoWebPage : Page
	{
		#region Properties

		private Div FormNavDiv { get { return Doc.Div(Find.ById("formnavContent")); } }

		private Div ContentAreaDiv { get { return Doc.Div(Find.ById("content")); } }

		private Div CommandBarDiv { get { return Doc.Div(Find.ById("formcommands")); } }

		public Div OutcomeArea { get { return ContentAreaDiv.Div(Find.ByText("Outcome")).Parent as Div; } }

		public SelectList OutcomeField { get { return OutcomeArea.SelectLists[0]; } }

		public Link FinalizeLink { get { return WaitForElement(() => Doc.Link(Find.ByClass("finalize"))); } }

		public Link SaveLink { get { return WaitForElement(() => Doc.Links.Filter(Find.ByClass("save")).First(link => IsVisible(link))); } }

		public Link CloseLink { get { return WaitForElement(() => Doc.Links.Filter(Find.ByClass("close")).First(link => IsVisible(link))); } }

		protected override Document Doc
		{
			get
			{
				WaitForExoWebCompleted();
				return base.Doc;
			}
		}

		public bool IsSaving
		{
			get
			{
				return SaveLink.Parent.ClassName.Contains("changes-inprogress");
			}
		}

		public bool CanSave
		{
			get
			{
				return !SaveLink.Parent.ClassName.Contains("disabled-button");
			}
		}

		#endregion

		#region Methods

		public bool IsVisible(Element element)
		{
			return (element.Style.Display ?? "").ToLower() != "none" &&
				(element.Parent == null || IsVisible(element.Parent));
		}

		public void Save()
		{
			Save<ExoWebPage>();
		}

		public T Save<T>()
			where T : ExoWebPage
		{
			SaveLink.ClickNoWait();
			WaitForExoWebCompleted();
			return this as T;
		}

		public void WaitForExoWebLoaded()
		{
			WaitUntil("Wait until ExoWeb scripts have been loaded",
				() => EvalScript("if (window.ExoWeb) { ExoWeb.Model && ExoWeb.Mapper && ExoWeb.View && ExoWeb.UI ? true : false; }") == "true");
		}

		public void WaitForExoWebCompleted()
		{
			WaitForExoWebLoaded();
			WaitUntil("Wait until ExoWeb loading and rendering is complete",
				() =>
				{
					AssertNoUnhandledScriptError();
					return EvalScript("if (window.ExoWeb && ExoWeb.isBusy) { ExoWeb.isBusy(); }") == "false";
				});
		}

		public bool SavePromptEnabled
		{
			set
			{
				Browser.RunScript("window.allowExit = " + (value ? "false" : "true") + ";");
			}
		}

		public void AllowExit()
		{
			Browser.RunScript("window.allowExit = true;");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="link"></param>
		/// <returns></returns>
		protected T NavigateTo<T>(Link link, bool forceExit)
			where T : Page, new()
		{
			if (forceExit)
				AllowExit();

			link.Click();
			return ((LeisureStarWebUI)UI).With<T>();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="button"></param>
		/// <returns></returns>
		protected T NavigateTo<T>(Button button, bool forceExit)
			where T : Page, new()
		{
			if (forceExit)
				AllowExit();

			button.Click();
			return ((LeisureStarWebUI)UI).With<T>();
		}

		#endregion

	}
}
