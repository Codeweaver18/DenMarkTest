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
        public async Task<IActionResult> CreateTest()
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTest(CreateTestViewModel model)
        {
            try
            {
                //create user here

                if (ModelState.IsValid)
                {
                    //_service.createTest();
                }
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
        public async Task<IActionResult> ViewList()
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
        /// Get detail view of a particular test that guid matches the supplied guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> TestDetails(string guid = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(guid))
                {
                    ViewData["TestDetailsGuid"] = guid.ToString();//setting the retrieved guid to be called from razor page by calling the injected service with @inject

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error has occured");
                StatusCode(500, ex.Message);
            }

            return View();
        }


        /// <summary>
        /// fetches detailed information about a specific athelete where the id matches the supplied id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> AtheleteDetails(int id=0)
        {
            try
            {
                if (id!=0)
                {
                    ViewData["AtheleteDetails"] = id.ToString();//setting the retrieved guid to be called from razor page by calling the injected service with @inject

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error has occured");
                StatusCode(500, ex.Message);
            }

            return View();
        }


        /// <summary>
        /// Delete the Specified Test which guid matches the supplied guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DeleteTest(string guid = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(guid))
                {
                    ViewData["DeleteTestGuid"] = guid.ToString();//setting the retrieved guid to be called from razor page by calling the injected service with @inject

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error has occured");
                StatusCode(500, ex.Message);
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> AddAtheleteToTest(string guid=null)
        {
            try
            {
                ViewData["AddAtheleteToTesttGuid"] = guid;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error has occured");
                StatusCode(500, ex.Message);
            }

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAtheleteToTest(int )
        {
            try
            {
                ///No logic

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error has occured");
                StatusCode(500, ex.Message);
            }

            return View();
        }


    }
}