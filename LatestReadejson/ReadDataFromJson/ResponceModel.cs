using System;
using System.Collections.Generic;

namespace ReadDataFromJson
{
	public class SearchOrgUsersResult
	{
		public int CompanyId { get; set; }
		public string Dept_Id { get; set; }
		public string Email { get; set; }
		public int Emp_Id { get; set; }
		public string FirstName { get; set; }
		public string FullName { get; set; }
		public string LastName { get; set; }
		public string MajorGroup_Id { get; set; }
		public string Org_Id { get; set; }
		public string Section_Id { get; set; }
		public int SecurityUserID { get; set; }
		public object UserTitle { get; set; }
		public string User_ID { get; set; }
	}

	public class RootObjectNew
	{
		public List<SearchOrgUsersResult> SearchOrgUsersResult { get; set; }
	}
}
