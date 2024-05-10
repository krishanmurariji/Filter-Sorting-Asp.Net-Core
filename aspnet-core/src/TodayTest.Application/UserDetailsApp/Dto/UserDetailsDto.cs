using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodayTest.Enums;

namespace TodayTest.UserDetailsApp.Dto
{
    public class UserDetailsDto:EntityDto<int>
    {
        public String MotherName { get; set; }
        public String FatherName { get; set; }
        public Gender Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public int Age { get; set; }
        public long UserId { get; set; }
    }
}
