using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DenMarkTest.core.Abstract;
using DenMarkTest.DataAccessLayer.Entities;
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
        private readonly IMapper _mapper;


        public TestsController(ILogger<TestsController> logger, ITestService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        /// <summary>
        /// Get Html View/Page for CreateTest
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> CreateTest()
        {

            try
            {
                //No Logic for Get Http Views;
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error has occured, Test May Not be created");

            }

            return View();
        }

        /// <summary>
        /// Create New Test using supplied Parameters in the viewModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTest(CreateTestViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.createTest(model.testType, model.testDate, model.testType);
                   return RedirectToAction("ViewList");//redirect to  Startpage after creating Test;
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
                    ViewData["TestParticipantsId"] = id.ToString();//setting the retrieved guid to be called from razor page by calling the injected service with @inject

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
        /// Updates A particular test with possible change of participant user, distance score
        /// </summary>
        /// <param name="participantId"></param>
        /// <param name="TestParticipantsId"></param>
        /// <param name="distance"></param>
        /// <returns></returns>

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AtheleteDetails(int participantId, int TestParticipantsId, int distance)
        {
            try
            {
                var result = await _service.updateTestParticipants(participantId, TestParticipantsId, distance);
                if (result != null)
                {
                    return RedirectToAction("TestDetails", new {guid = result.Test.guid });
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
        /// Delete A particular Athelete Participant from the test table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            var tpant = new TestParticipants();
            try
            {
                     tpant = await _service.getTestParticipant(id);
                    var result = await _service.deleteTestParticipants(id);
               
                   if (tpant.Test==null)
                {
                    return RedirectToAction("TestDetails", new { guid =string.Empty});
                }
                return RedirectToAction("TestDetails", new { guid = tpant.Test.guid });

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
                 var res=  await  _service.deleteTest(guid);

                    if (res)
                    {
                        _logger.LogInformation(guid + "::Has been deleted successfully");

                        return RedirectToAction("ViewList");

                    }
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


        /// <summary>
        /// Add a specific user to the specified test with the supplied Guid
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="testGuid"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAtheleteToTest(int userId, string testGuid, int distance)
        {
            try
            {
                var result =await  _service.addParticipantstoTest(userId, testGuid, distance);

                if (result)
                {
                    _logger.LogInformation(userId.ToString() + ":: Has been Added to Test with Guid::" + testGuid);
                }

                return RedirectToAction("TestDetails", new {guid = testGuid});
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