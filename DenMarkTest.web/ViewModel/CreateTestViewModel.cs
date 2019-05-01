using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DenMarkTest.web.ViewModel
{
    public class CreateTestViewModel
    {

        [Required(AllowEmptyStrings =false,ErrorMessage ="Test Type is required to create a new test")]
        [Display(Name ="Type")]
        public string testType { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Test Date is required to create a new test")]
        public DateTime dateCreated { get; set; }

    }
}
