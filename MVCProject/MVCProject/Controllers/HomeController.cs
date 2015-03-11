using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MVCProject.Controllers {
	public class HomeController : Controller {
		ApplicationDbContext context = new ApplicationDbContext();

		public ActionResult Index(int? Page) {
			return View(context.BlogEntries.OrderByDescending(m => m.Created).ToPagedList(Page ?? 1, 3));
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

		public ActionResult BlogList(string User, string Tag, int? Page) {
			List<BlogEntry> list = new List<BlogEntry>(context.BlogEntries.ToList().OrderByDescending(b => b.Created));
			if (!string.IsNullOrEmpty(User)) {
				string uName = User.ToString();
				if (context.Users.Any(u => u.UserName == uName)) {
					ApplicationUser _user = context.Users.First(u => u.UserName == uName); 
					list = list.FindAll(b => b.Author == _user);
				} else {
					return View(new List<BlogEntry>());
				}
			}
			if (!string.IsNullOrEmpty(Tag)) {
				string tagName = Tag.ToString();
				if (context.Tags.Any(t => t.InternalName == tagName)) {
					Tag _tag = context.Tags.First(t => t.InternalName == tagName);
					list = list.FindAll(b => b.Tags.Contains(_tag));
				} else {
					return View(new List<BlogEntry>());
				}
			}
			return View(list.ToPagedList(Page ?? 1, 3));
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				context.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}