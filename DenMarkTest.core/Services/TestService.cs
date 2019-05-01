using DenMarkTest.core.Abstract;
using DenMarkTest.core.Responses;
using DenMarkTest.DataAccessLayer.Entities;
using DenMarkTest.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DenMarkTest.core.Services
{
    /// <summary>
    /// Test Services for all logic directly related to tests;
    /// </summary>
    public class TestService : ITestService
    {
        private readonly ITestsRepository _repo;

        public TestService(ITestsRepository repo)
        {
            _repo = repo;
        }
        /// <summary>
        /// Create New Test based on the parameters supplied;
        /// </summary>
        /// <param name="testType"></param>
        /// <param name="testDate"></param>
        /// <returns></returns>
        public async Task<response> createTest(string testType, DateTime testDate, string description)
        {
            var entity = new Test();
            var res = new response();
            try
            {
                if (string.IsNullOrEmpty(testType) || string.IsNullOrEmpty(testDate.ToString()))
                {
                    res.responseMessage = "Please all parameters are required";
                    
                }

                entity.testDate = testDate;
                entity.testDescription = description;
                entity.testType = testType;

               var result= await _repo.createTest(entity);
                if (result.id>0)
                {
                    res.responseObject = result;
                    res.responseDescription = ResponseMessages.success;
                    res.responseCode = ResponseCodes.success;
                    res.responseMessage = ResponseMessages.success;
                }  
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return res;
        }

        /// <summary>
        /// Fetches all the Test created on the database
        /// </summary>
        /// <returns></returns>
        public async Task<response> getAllTest()
        {
            var res = new response();
            try
            {
                var result =await  _repo.getTest();
                if (result!=null)
                {
                    res.responseObject = result;
                    res.responseDescription = ResponseMessages.success;
                    res.responseCode = ResponseCodes.success;
                    res.responseMessage = ResponseMessages.success;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return res;
        }
        /// <summary>
        /// Fetches all the Type of test recorded in the database                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
        /// </summary>
        /// <returns></returns>
        public async Task<response> getTestTypes()
        {
            var res = new response();
            try
            {
                var result = await _repo.getTestTypes();
                if (result!=null)
                {
                    res.responseObject = result;
                    res.responseDescription = ResponseMessages.success;
                    res.responseCode = ResponseCodes.success;
                    res.responseMessage = ResponseMessages.success;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return res;
        }                    
    }
}
