using System;
using System.Collections.Generic;
using System.Text;

namespace DenMarkTest.DataAccessLayer.Entities
{
    public class Test:BaseEntity
    {
        static Random random = new Random();  
      
      
        public string testType { get; set; }
        public DateTime testDate { get; set; }
        public string guid { get; set; } = random.Next(2443334, 504343440).ToString();
        public string testDescription { get; set; }
        public virtual IEnumerable<TestParticipants> TestParticipants { get; set; }
    }
}
