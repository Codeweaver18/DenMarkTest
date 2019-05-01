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
        /// Add a specific Athelete to a specific test
        /// </summary>
        /// <param name="atheleteId"></param>
        /// <param name="testGuid"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public async Task<bool> addParticipantstoTest(int atheleteId, string testGuid, int distance)
        {
            var isDone = false;
            try
            {
                isDone = await _repo.addParticipantstoTest(atheleteId, testGuid, distance);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return isDone;
        }

        /// <summary>
        /// Create New Test based on the parameters supplied;
        /// </summary>
        /// <param name="testType"></param>
        /// <param name="testDate"></param>
        /// <returns></returns>
        public async Task<Test> createTest(string testType, DateTime testDate, string description)
        {
            var entity = new Test();
            try
            {
                if (!string.IsNullOrEmpty(testType) && !string.IsNullOrEmpty(testDate.ToString()))
                {
                    entity.testDate = testDate;
                    entity.testDescription = description;
                    entity.testType = testType;

                }

              
               var result= await _repo.createTest(entity);
               
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return entity;
        }

        /// <summary>
        /// Delete a Test based on matching guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<bool> deleteTest(string guid)
        {
            var isDelete = false;
            try
            {
                isDelete = await _repo.deleteTestByGuid(guid);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return isDelete;
        }

        /// <summary>
        /// Fetches all the Test created on the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<Test>> getAllTest()
        {
            var res = new List<Test>();
            try
            {
                res =await  _repo.getTest();
               
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return res;
        }


        /// <summary>
        /// Fetches Recorded Test that guid matches the supplied guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<Test> getTestByGuid(string guid)
        {
            var res = new Test();
            try
            {
                res = await _repo.getTestByGuid(guid);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return res;
        }

        public Task<TestParticipants> getTestParticipant(int participantId, int TestParticipantsId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetches from repo all tests and participants records
        /// </summary>
        /// <returns></returns>
        public async Task<List<TestParticipants>> getTestParticipants()
        {
            var res = new List<TestParticipants>();
            try
            {
                res = await _repo.getTestParticipants();
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
        public async Task<List<TestTypes>> getTestTypes()
        {
            var res = new List<TestTypes>();
            try
            {
                 res= await _repo.getTestTypes();
               
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return res;
        }

        /// <summary>
        /// Fetches all the application users via the data repository
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> ListUsers()
        {
            var res =new List<User>();
            try
            {
                res = await _repo.listUsers();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return res;
        }

        public Task<TestParticipants> updateTestParticipants(int participantId, int TestParticipantsId, int distance)
        {
            throw new NotImplementedException();
        }
    }
}
