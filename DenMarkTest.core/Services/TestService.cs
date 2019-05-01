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
        /// Delete single Test Participants by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> deleteTestParticipants(int id)
        {
            var isDone = false;
            try
            {
                isDone = await _repo.deleteTestParticipants(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return isDone;
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


        /// <summary>
        /// Get A single record of Test Participants where id=TestParticipantsId
        /// </summary>
        /// <param name="TestParticipantsId"></param>
        /// <returns></returns>
        public async Task<TestParticipants> getTestParticipant(int TestParticipantsId)
        {
            var res = new TestParticipants();
            try
            {
                res = await _repo.getTestParticipant(TestParticipantsId);
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return res;
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


        /// <summary>
        /// update a particular test entry for a registered user which criteria matches supplied params;
        /// </summary>
        /// <param name="participantId"></param>
        /// <param name="TestParticipantsId"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public  async Task<TestParticipants> updateTestParticipants(int participantId, int TestParticipantsId, int distance)
        {
            var tpants =new  TestParticipants();
            try
            {
                tpants = await _repo.updateTestParticipants(participantId, TestParticipantsId, distance);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return tpants;
        }
    }
}
