using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models {
	/// <summary>
	/// A model class intended for passing information from the Home Controller to its Index View
	/// </summary>
	public class HomeIndexModel {
		public IEnumerable<BlogEntry> BlogPosts;

		public HomeIndexModel() {
			this.BlogPosts = new HashSet<BlogEntry>();
		}
	}
}