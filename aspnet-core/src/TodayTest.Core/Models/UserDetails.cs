using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using TodayTest.Enums;
using TodayTest.Authorization.Users;

namespace TodayTest.Models
{
    public class UserDetails:Entity<int>
    {
        public String MotherName { get; set; }
        public String FatherName { get; set; }
        public Gender Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public int Age { get; set; }
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
