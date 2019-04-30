using DenMarkTest.DataAccessLayer.Dbcontexts;
using DenMarkTest.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
