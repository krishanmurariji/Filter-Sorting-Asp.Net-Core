using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodayTest.Enums;

namespace TodayTest.UserDetailsApp.Dto
{
    public class UserDetailOutputDto { 
        public string motherName { get; set; }
        public string fatherName { get; set; }
   
        public int age { get; set; }
        public MaritalStatus maritalStatus { get; set; }
        public Gender gender { get; set; }
        public string fullname { get; set; }
       
        public string email {  get; set; }
      
    }
}
