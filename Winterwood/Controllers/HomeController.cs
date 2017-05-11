using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Winterwood.Models;
using Winterwood.DAL;

using Microsoft.Extensions.Logging;

namespace Winterwood.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        private readonly ILogger _logger;
        private ILogger _logger1;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public HomeController(ILogger logger1)
        {
            _logger1 = logger1;
        }

        public IActionResult Index()
        {
            _logger.LogDebug("User Accessed Site"); 

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
