using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodayTest.Models;
using TodayTest.UserDetailsApp.Dto;


namespace TodayTest
{
    public class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<UserDetailsDto, UserDetails>().ReverseMap();          
        }
    }
}
