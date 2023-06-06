using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppAPI.Models;
using System.Data.Entity.Infrastructure;
using System.Web.Http.Description;

namespace WebAppAPI.Controllers
{
	public class EmployeeController : ApiController
	{
		private TSQL2012Entities db = new TSQL2012Entities();

		public IQueryable<tblEmployee> GetTblEmployees()
		{
			return db.tblEmployees;
		}

		public IHttpActionResult GettblEmployees(int id)
		{
			tblEmployee myEmp = db.tblEmployees.Find(id);

			if (Convert.ToString(myEmp).Length == 0 || myEmp == null)
			{
				return NotFound();
			}

			return Ok(myEmp);
		}

		public IHttpActionResult PuttblEmployees(int id, tblEmployee tblEmployees)
		{

			if (id != tblEmployees.emp_id)
			{
				return BadRequest();
			}

			db.Entry(tblEmployees).State = System.Data.Entity.EntityState.Modified;



			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!tblEmployeesExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return StatusCode(HttpStatusCode.NoContent);
		}


		// POST api/Employee
		[ResponseType(typeof(tblEmployee))]
		public IHttpActionResult PostEmployee(tblEmployee employee)
		{

			db.tblEmployees.Add(employee);
			db.SaveChanges();

			return CreatedAtRoute("DefaultApi", new { id = employee.emp_id }, employee);
		}

		// DELETE api/Employee/5
		[ResponseType(typeof(tblEmployee))]
		public IHttpActionResult DeleteEmployee(int id)
		{
			tblEmployee employee = db.tblEmployees.Find(id);
			if (employee == null)
			{
				return NotFound();
			}

			db.tblEmployees.Remove(employee);
			db.SaveChanges();

			return Ok(employee);
		}


		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
		private bool tblEmployeesExists(int id)
		{
			return db.tblEmployees.Count(e => e.emp_id == id) > 0;
		}

	}
}