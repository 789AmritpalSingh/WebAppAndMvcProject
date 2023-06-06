using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMvc.Models
{
	public class MvcEmployee
	{
		public int emp_id { get; set; }

		[Required (ErrorMessage ="Please enter your name")]
		[DataType (DataType.Text)]
		public string emp_name { get; set; }

		[Required (ErrorMessage = "Please enter your email")]
		[DataType (DataType.EmailAddress)]
		public string emp_email { get; set; }
		public string emp_password { get; set; }
		public string emp_gender { get; set; }
		public Nullable<int> noOfDependants { get; set; }
		public Nullable<decimal> Additions { get; set; }
		public Nullable<decimal> ITex { get; set; }
		public Nullable<decimal> CPP { get; set; }
		public Nullable<decimal> EI { get; set; }
		public Nullable<decimal> GrossSalary { get; set; }
	}
}