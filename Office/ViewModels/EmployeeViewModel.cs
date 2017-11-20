using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Office.ViewModels
{
    public class EmployeeViewModel
    {
            public int Id { get; set; }

            [Required(AllowEmptyStrings =false,ErrorMessage ="This field is Required")]
            public string FirstName { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "This field is Required")]
            public string LastName { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "This field is Required")]
            public string Designation { get; set; }

    }
}