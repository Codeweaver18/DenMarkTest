using System;
using System.Collections.Generic;
using System.Text;

namespace DenMarkTest.DataAccessLayer.Entities
{
    public class TestTypes:BaseEntity
    {
        public string testType { get; set; }
        public string testDescription { get; set; }
    }
}
