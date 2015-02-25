using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models {
	public class BlogEntry {
		public int Id { get; set; }

		public string Title { get; set; }
		public string Content { get; set; }

		public DateTime Created { get; set; }

		public ApplicationUser Author { get; set; }
		public List<Comment> Comments { get; set; }

		public BlogEntry VersionHistory { get; set; }
	}
}