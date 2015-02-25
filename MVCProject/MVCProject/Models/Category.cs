using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models {
	public class Category {
		public int Id { get; set; }
		public string Display { get; set; }
		public string InternalName { get; set; }
		public List<BlogEntry> Entries { get; set; }
	}
}