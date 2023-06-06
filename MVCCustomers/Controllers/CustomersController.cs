using Microsoft.AspNetCore.Mvc;
using MVCCustomers.Models;

namespace MVCCustomers.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            List<Customers>myList = new List<Customers>();
            myList.Add(new Customers() { Customer_id = 1,Customer_name = "Amrit",Customer_balance = 1500 }) ;
            myList.Add(new Customers() { Customer_id = 2, Customer_name = "Divya", Customer_balance = 3000 });
            myList.Add(new Customers() { Customer_id = 3, Customer_name = "John", Customer_balance = 700 });
            myList.Add(new Customers() { Customer_id = 4, Customer_name = "Tony", Customer_balance = 500 });

            var myQuery = from cust in myList
                          where cust.Customer_balance>1000
                          select cust;

            return View(myQuery);
        }

        public IActionResult Show()
        {
            return View();
        }
    }
}
