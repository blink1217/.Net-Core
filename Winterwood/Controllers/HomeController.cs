using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Winterwood.Models;
using Winterwood.DAL; 

namespace Winterwood.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(); 

        public IActionResult Index()
        {
            var invoice = unitOfWork.InvoiceRepository.Get(includeProperties: "Account"); 
            return View(invoice.ToList());
        }
        [HttpPost]
        public IActionResult Index(string name)
        {
            Account account = unitOfWork.AccountRepository.Get( e => e.Name == name, includeProperties: "Invoice").FirstOrDefault();
            var invoice = unitOfWork.InvoiceRepository.Get(e => e.AccountId == account.AccountId, includeProperties: "Account");


            return View(invoice.ToList()); 
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
