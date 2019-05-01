using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DenMarkTest.core.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DenMarkTest.web.Controllers
{
    public class TestsController : Controller
    {
        private readonly ILogger<TestsController> _logger;
        private readonly ITestService _service;

        public TestsController(ILogger<TestsController> logger, ITestService service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet]
        public IActionResult CreateTest()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTest()
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return View();
        }


        [HttpGet]
        public IActionResult List()
        {

            return View();
        }

    }
}