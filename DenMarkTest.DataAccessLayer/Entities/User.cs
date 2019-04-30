using System;
using System.Collections.Generic;
using System.Text;

namespace DenMarkTest.DataAccessLayer.Entities
{
    public class User:BaseEntity
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string username {
            get {

                return fname;

            }

        }
    }
}
