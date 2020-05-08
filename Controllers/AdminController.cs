using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using frame.Models;
using frame.Data;
using Microsoft.Extensions.DependencyInjection;

namespace frame.Controllers
{
    public class AdminController : Controller
    {


        public IActionResult Index() {
            return View();
        }
        public IActionResult BookManagement() {
            return View();
        }
        public IActionResult AccountManagement() {
            return View();
        }
        //employee
        public IActionResult EmployeeManagement() {
            BookStoreContext context = new BookStoreContext();
            var employee = context.GetAllemployee();
            var employees = employee.Where(e=>e.status == "true");
            var users = context.GetAllUser();
            ViewBag.employee = employees;
            ViewBag.users = users;
            
            return View();
        }
        [HttpPost]
         public IActionResult AddEmployee(Employee emp) {
            BookStoreContext context = new BookStoreContext();
            context.AddEmployee(emp);
            return RedirectToAction("EmployeeManagement");
        }
         public IActionResult EmployeeDelete(string id) {
            // Console.WriteLine("vo");
            BookStoreContext context = new BookStoreContext();
            context.DeleteEmployee(id);
            return RedirectToAction("EmployeeManagement");
        }
        //customer
        public IActionResult CustomerManagement() {
            BookStoreContext context = new BookStoreContext();
            var customer = context.GetAllCustomer();
            var users = context.GetAllUser();
            var customers = customer.Where(c=>c.status == "true");
            var shippings = context.GetAllShipping();
            ViewBag.shippings = shippings;
            ViewBag.customer = customers;
            ViewBag.users = users;
            return View();
        }
         public IActionResult AddCustomer() {
            return View();
        }
        [HttpPost]
         public IActionResult AddCustomer(Customer cus) {
            BookStoreContext context = new BookStoreContext();
            context.AddCustomer(cus);
            return RedirectToAction("CustomerManagement");
        }
        public IActionResult CustomerDelete(string id) {
            // Console.WriteLine("vo");
            BookStoreContext context = new BookStoreContext();
            context.DeleteCustomer(id);
            return RedirectToAction("CustomerManagement");
        }

         public IActionResult UpdateCustomer(string id){
            BookStoreContext context = new BookStoreContext();
            List<Customer> customers = context.GetAllCustomer();
            var x = customers.Where(d => d.idCustomer == id).FirstOrDefault();
            ViewBag.customer = x;
            return View();
        }


        //order
        public IActionResult OrderManagement() {
            return View();
        }
        //shipping
        public IActionResult ShippingManagement() {
            BookStoreContext context = new BookStoreContext();
            var shippings = context.GetAllShipping();
            ViewBag.shippings = shippings;
            return View();
        }
        //discount
        public IActionResult DiscountManagement() {
            BookStoreContext context = new BookStoreContext();
            var discount = context.GetAllDiscount();
            var discounts = discount.Where(d=>d.status == "true");
            ViewBag.discount = discounts;
            return View();
        }
        public IActionResult AddDiscount() {
            return View();
        }
        [HttpPost]
        public IActionResult AddDiscount(Discount dis) {
            BookStoreContext context = new BookStoreContext();
            context.AddDiscount(dis);
            return RedirectToAction("DiscountManagement");
        }
        public IActionResult UpdateDiscount(string id){
            BookStoreContext context = new BookStoreContext();
            List<Discount> discounts = context.GetAllDiscount();
            var x = discounts.Where(d => d.idDiscount == id).FirstOrDefault();
            ViewBag.discount = x;
            return View();
        }

        public IActionResult DiscountDelete(string id) {
            // Console.WriteLine("vo");
            BookStoreContext context = new BookStoreContext();
            context.DeleteDiscount(id);
            return RedirectToAction("DiscountManagement");
        }


       
        public IActionResult AddEmployee() {
            return View();
        }
    }
}