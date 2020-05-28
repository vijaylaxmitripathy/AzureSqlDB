using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SQLServerAzureProj.Models;

namespace SQLServerAzureProj.Controllers
{
    public class HomeController : Controller
    {
        rmgazuresqldbEntities db = new rmgazuresqldbEntities();
        public ActionResult Index()
        {
            List<Customer> cusList = db.Customers.ToList();

            return View(cusList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            Customer cus = db.Customers.Find(id);
            return View(cus);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            Customer emp = db.Customers.Find(id);
            return View(emp);
        }

        public ActionResult Delete(int? id)
        {
            Customer emp = db.Customers.Find(id);

            return View(emp);
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            Customer cus = db.Customers.Find(customer.ID);
            db.Customers.Remove(cus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}