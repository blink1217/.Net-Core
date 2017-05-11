using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Winterwood.Controllers;
using Winterwood.DAL;
using Winterwood.Models;
using Moq;
using Microsoft.EntityFrameworkCore;


namespace Winterwood.Tests.UnitTests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Index_ReturnsAViewResult()
        {
            // Arrange

            var controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.Model); 

           
        }

    }
}
