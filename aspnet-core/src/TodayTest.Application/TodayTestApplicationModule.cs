using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TodayTest.Authorization;

namespace TodayTest
{
    [DependsOn(
        typeof(TodayTestCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TodayTestApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TodayTestAuthorizationProvider>();
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TodayTestApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
