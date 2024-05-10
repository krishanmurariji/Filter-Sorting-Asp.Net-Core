using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayTest.UserDetailsApp.Dto
{
    public class UserDetailsPageDto: PagedResultRequestDto
    {
        public string Keyword { get; set; }
        //public int? Userid { get; set; } 

    }
}
