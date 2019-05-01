using DenMarkTest.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DenMarkTest.DataAccessLayer.Interfaces
{
   public interface ITestsRepository
    {
        Task<Test> createTest(Test entity);
        Task<List<Test>> getTest(int count=0);
        Task<List<TestTypes>> getTestTypes();

    }
}
