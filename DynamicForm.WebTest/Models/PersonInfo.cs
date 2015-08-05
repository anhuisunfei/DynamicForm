using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using DynamicForm.Core.Attribute;

namespace DynamicForm.WebTest.Models
{
    [FormData(FormCols = 6, GridHeader = "")]
    public class Person
    {
        [Display(Name = "姓名")]
        [Required]
        [StringLength(2)]
        public string PersonName { get; set; }

        [Display(Name = "年龄")]
        [Required]
        [Range(0, 120)]
        public int Age { get; set; }

        [Display(Name = "手机号码")]
        public string PhoneNumber { get; set; }

        [Display(Name="联系方式")]
        public string Contract { get; set; }

        [Display(Name="性别")]
        [DynamicForm(InputType=InputFiledType.CheckBox)]
        public bool Sex { get; set; }
    }
}