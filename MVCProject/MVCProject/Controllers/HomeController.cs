using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Details(int id, [Bind(Include = "Title,Content,User")] Comment comment) {
			BlogEntry current = context.BlogEntries.First(b => b.Id == id);
			string guid = HttpContext.User.Identity.GetUserId();
			ApplicationUser user = context.Users.First(u => u.Id == guid);
			current.AddComment(comment);
			user.AddComment(comment);
			comment.Created = DateTime.Now;

			context.Comments.Add(comment);
			context.SaveChanges();
			return View(current);
		}

		[HttpGet]
		public ActionResult BlogList(int User, int Tag) {
			List<BlogEntry> list = new List<BlogEntry>();
			return View();
		}

		[HttpGet]
		public ActionResult CommentList(int User) {
			return View();
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				context.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}