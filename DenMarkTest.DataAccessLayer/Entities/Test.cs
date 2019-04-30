﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DenMarkTest.DataAccessLayer.Entities
{
    public class Test:BaseEntity
    {
        public string testName { get; set; }
        public string guid { get; set; } = new Random(383784).ToString();
        public string testDescription { get; set; }
    }
}