using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DenMarkTest.DataAccessLayer.Entities
{
    public class TestParticipants:BaseEntity
    {
       [ForeignKey("TestId")]
        public Test Test { get; set; }
        [ForeignKey("ParticipantId")]
        public User Participant { get; set; }
        public string Result { get; set; }

    }
}
