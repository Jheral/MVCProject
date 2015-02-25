using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models {
	public class Comment : BlogEntry {
		public BlogEntry ParentEntry { get; set; }
		public int Rating { get; set; }
	}
}