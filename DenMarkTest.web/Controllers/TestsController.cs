using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DenMarkTest.core.Abstract;
using DenMarkTest.web.ViewModel;
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
        public async Task<IActionResult> CreateTest(CreateTestViewModel model)
        {
            try
            {

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An Error has occured, Test May Not be created");
            }

            return View();
        }

        /// <summary>
        /// View List of all the tests on the database with it corresponding number of participants order by dates
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ViewList()
        {

            try
            {

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error has occured, Test May Not be created");

            }


            return View();
        }

    }
}