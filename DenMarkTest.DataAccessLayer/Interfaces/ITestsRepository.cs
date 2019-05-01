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
        Task<List<TestParticipants>> getTestParticipants();
        Task<Test> getTestByGuid(string guid);
        Task<bool> deleteTestByGuid(string guid);
        Task<bool> addParticipantstoTest(int atheleteId, string testGuid, int distance);
        Task<TestParticipants> getTestParticipant(int participantId, int TestParticipantsId);
        Task<TestParticipants> updateTestParticipants(int participantId, int TestParticipantsId, int distance);


    }
}
