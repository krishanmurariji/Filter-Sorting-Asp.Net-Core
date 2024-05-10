using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TodayTest.EntityFrameworkCore;
using TodayTest.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace TodayTest.Web.Tests
{
    [DependsOn(
        typeof(TodayTestWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class TodayTestWebTestModule : AbpModule
    {
        public TodayTestWebTestModule(TodayTestEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TodayTestWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(TodayTestWebMvcModule).Assembly);
        }
    }
}