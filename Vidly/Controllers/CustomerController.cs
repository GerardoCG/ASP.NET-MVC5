using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Models.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MemberShipType.ToList();
            var viewModel = new CustomerFormViewModel {
                Customer = new Customer(),
                MemberShipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var vieModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MemberShipTypes = _context.MemberShipType.ToList()
                };
                return View("CustomerForm", vieModel);
            }

            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //Mapper.Map(customer, customerInDb);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDay = customer.BirthDay;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction("ListCostumers", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var cusomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (cusomer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = cusomer,
                MemberShipTypes = _context.MemberShipType.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        // GET: Customer
        public ActionResult ListCostumers()
        {
            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int Id)
        {
            Customer customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(x => x.Id == Id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}