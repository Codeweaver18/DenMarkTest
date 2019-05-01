using DenMarkTest.core.Responses;
using DenMarkTest.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DenMarkTest.core.Abstract
{
  public  interface ITestService
    {
        Task<List<Test>> getAllTest();
        Task<Test> createTest(string testType, DateTime testDate, string description);
        Task<List<TestTypes>> getTestTypes();
        Task<List<TestParticipants>> getTestParticipants();
        Task<Test> getTestByGuid(string guid);
        Task<bool> deleteTest(string guid);
        Task<List<User>> ListUsers();
        Task<bool> addParticipantstoTest(int atheleteId, string testGuid, int distance);
        Task<TestParticipants> getTestParticipant(int TestParticipantsId);
        Task<TestParticipants> updateTestParticipants(int participantId, int TestParticipantsId, int distance);
        Task<bool> deleteTestParticipants(int id);



    }
}
          