using DenMarkTest.DataAccessLayer.Dbcontexts;
using DenMarkTest.DataAccessLayer.Entities;
using DenMarkTest.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DenMarkTest.DataAccessLayer.Repositories
{
    public class TestsRepository: GenericRepository<TestsRepository>, ITestsRepository
    {
        private DanishContext _dbContext;

        public TestsRepository(DanishContext dbContext)
            :base(dbContext)
        {

            _dbContext = dbContext;
        }
        /// <summary>
        /// Adding Users/Participants to Existing test in the database;
        /// </summary>
        /// <param name="atheleteId"></param>
        /// <param name="testGuid"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public async Task<bool> addParticipantstoTest(int atheleteId, string testGuid, int distance)
        {
            var tPants = new TestParticipants();
            var testByGuid = new Test();
            var testUser = new User();
            var isDone = false;
            try
            {
                if (atheleteId!=0 && !string.IsNullOrEmpty(testGuid) && distance!=0)//check for null values
                {
                    testByGuid = (from x in _dbContext.Tests where x.guid == testGuid select x).FirstOrDefault();//fetches tests
                    testUser = (from c in _dbContext.Users where c.id == atheleteId select c).FirstOrDefault();//fetches participants
                    tPants.Result = distance.ToString();
                    tPants.Test = testByGuid;
                    tPants.Participant = testUser;
                }

               await _dbContext.TestParticipants.AddAsync(tPants);
                var result = await _dbContext.SaveChangesAsync();

                if (result>0)
                {
                    isDone = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return isDone;
        }

        /// <summary>
        /// Create/Persist New Test to the database {Test Table}
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Test> createTest(Test entity)
        {
            
            try
            {
                if (entity!=null)
                {
                  await  _dbContext.Tests.AddAsync(entity);
                    await _dbContext.SaveChangesAsync();
                  
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return entity;
        }


        /// <summary>
        /// Delete test that Guid Matches the supplied guid as Param
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<bool> deleteTestByGuid(string guid)
        {
            var isDelete = false;
            var test = new Test();
            try
            {
                test = (from x in _dbContext.Tests where x.guid == guid select x).FirstOrDefault();
                if (test!=null)
                {
                    _dbContext.Tests.Remove(test);
                    var result = await _dbContext.SaveChangesAsync();

                    if (result>0)
                    {
                        isDelete = true;
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return isDelete;
        }


        /// <summary>
        /// Delete single test participants entry
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> deleteTestParticipants(int id)
        {
            var isDone = false;
            var tpant = (from x in _dbContext.TestParticipants where x.id==id select x).FirstOrDefault();
            try
            {
                ///detelet
                _dbContext.TestParticipants.Remove(tpant);
                var result =await _dbContext.SaveChangesAsync();
                if (result>0)
                {
                    isDone = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return isDone;
        }

        /// <summary>
        /// get all the recorded test in the system if the test count = 0; else it takes the specified number given by count parameter;
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<List<Test>> getTest(int count=0)
        {
            var tests = new List<Test>();
            try
            {

                if (count>0)
                {
                    tests = (from c in _dbContext.Tests select c).Take(count).ToList();

                }
      
                tests = (from c in _dbContext.Tests select c).ToList();


            }
            catch (Exception ex)
            {
                //throw exception to outer layer to be properly manage and hand;e
                throw ex;
            }
            return tests;
        }



        /// <summary>
        /// Get a single Test Details that guid matches the supplied guid in Params supplied
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<Test> getTestByGuid(string guid)
        {
            var res = new Test();

            try
            {
                res = (from x in _dbContext.Tests where x.guid == guid select x).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return res;
        }


        /// <summary>
        /// Get Athelete Participant of a certain test
        /// </summary>
        /// <param name="participantId"></param>
        /// <param name="TestParticipantsId"></param>
        /// <returns></returns>
        public async Task<TestParticipants> getTestParticipant(int TestParticipantsId)
        {
            var participants = new TestParticipants();
            try
            {
                participants = (from x in _dbContext.TestParticipants where x.id == TestParticipantsId select x).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return participants;

        }


        /// <summary>
        /// fetches al the test carried out and it participants
        /// </summary>
        /// <returns></returns>
        public async Task<List<TestParticipants>> getTestParticipants()
        {
            var res = new List<TestParticipants>();
            try
            {
                res = (from c in _dbContext.TestParticipants select c).OrderByDescending(x => x.Test.testDate).ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }


            return res;
        }


        /// <summary>
        /// Get all the types of test recorded on the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<TestTypes>> getTestTypes()
        {
            var testTypeList = new List<TestTypes>();

            try
            {
                testTypeList = (from c in _dbContext.TestTypes select c).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return testTypeList;

        }

        /// <summary>
        /// List All the Registered user in the system
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> listUsers()
        {
            var usersList = new List<User>();

            try
            {
                usersList = (from x in _dbContext.Users select x).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return usersList;
        }

        /// <summary>
        /// Update the Participants id and distance of a certain test that matches the TestParticipationId supplied
        /// </summary>
        /// <param name="participantId"></param>
        /// <param name="TestParticipantsId"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public async Task<TestParticipants> updateTestParticipants(int participantId, int TestParticipantsId, int distance)
        {
            var testPant = new TestParticipants();
            try
            {
               if (participantId!=0 && TestParticipantsId!=0 && distance!=0)
                {
                    testPant = (from x in _dbContext.TestParticipants where x.id == TestParticipantsId select x).FirstOrDefault();

                    if (testPant!=null)
                    {
                        testPant.Participant.id = participantId;
                        testPant.Result = distance.ToString();
                    }

                    _dbContext.TestParticipants.Update(testPant);
                    var result = await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return testPant;
        }
    }
}
