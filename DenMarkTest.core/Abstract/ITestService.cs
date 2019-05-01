using DenMarkTest.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DenMarkTest.core.Abstract
{
  public  interface ITestService
    {
        Task<TestParticipants> getAllTest();
        Task<Test> createTest(string testType, DateTime testDate);

    }
}
