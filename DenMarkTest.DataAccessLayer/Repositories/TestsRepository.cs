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

        public Task<bool> addParticipantstoTest(int atheleteId, string testGuid, int distance)
        {
            throw new NotImplementedException();
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

        public Task<TestParticipants> getTestParticipant(int participantId, int TestParticipantsId)
        {
            throw new NotImplementedException();
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

        public Task<TestParticipants> updateTestParticipants(int participantId, int TestParticipantsId, int distance)
        {
            throw new NotImplementedException();
        }
    }
}
