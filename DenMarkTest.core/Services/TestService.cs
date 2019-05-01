using DenMarkTest.core.Abstract;
using DenMarkTest.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DenMarkTest.core.Services
{
    public class TestService : ITestService
    {
        public Task<Test> createTest(string testType, DateTime testDate)
        {
            throw new NotImplementedException();
        }

        public Task<TestParticipants> getAllTest()
        {
            throw new NotImplementedException();
        }
    }
}
