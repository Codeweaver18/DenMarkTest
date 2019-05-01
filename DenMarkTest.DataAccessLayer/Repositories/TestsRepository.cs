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
    }
}
