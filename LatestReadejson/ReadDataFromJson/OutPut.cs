using System;
using System.Collections.Generic;

namespace ReadDataFromJson
{
	public class Element
	{
		public string type { get; set; }
		public int width { get; set; }
		public int height { get; set; }
		public int top { get; set; }
		public int left { get; set; }
		public string file { get; set; }
	}

	public class Page
	{
		public string pageId { get; set; }
		public string type { get; set; }
		public List<Element> elements { get; set; }
	}

	public class Index
	{
		public int width { get; set; }
		public int height { get; set; }
		public int top { get; set; }
		public int left { get; set; }
		public string goTo { get; set; }
	}

	public class RootObject
	{
		public bool debug { get; set; }
		public List<string> sequence { get; set; }
		public List<Page> pages { get; set; }
		public List<Index> index { get; set; }
	}
}
