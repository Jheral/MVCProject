using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers {
	public class HomeController : Controller {
		ApplicationDbContext context = new ApplicationDbContext();

		public ActionResult Index(int offset = 0) {
			return View(context.BlogEntries);
		}

		public ActionResult About() {
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact() {
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Details(int id) {
			
			return View(context.BlogEntries.First(b => b.Id == id));
		}
	}
}