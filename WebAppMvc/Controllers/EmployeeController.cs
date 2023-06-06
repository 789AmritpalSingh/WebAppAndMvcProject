using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAppMvc.Globals;
using WebAppMvc.Models;

namespace WebAppMvc.Controllers
{
    public class EmployeeController : Controller
    {
        
        public ActionResult Index()
        {
            IEnumerable<MvcEmployee> empList;

            HttpResponseMessage response = GlobalVariables.WebApiClient.
                GetAsync("Employee").Result;
			empList = response.Content.ReadAsAsync
                <IEnumerable<MvcEmployee>>().Result;

            return View(empList);
        }
    }
}