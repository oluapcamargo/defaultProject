using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace V1.DefaultProject.Config.Extension
{
    public static class AutomapperExtension
    {
        public static void ConfigureAutomapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.ForAllMaps((obj, cnfg) => cnfg.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)));
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
