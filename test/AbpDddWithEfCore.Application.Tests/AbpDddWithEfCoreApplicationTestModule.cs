using Volo.Abp.Modularity;

namespace AbpDddWithEfCore;

[DependsOn(
    typeof(AbpDddWithEfCoreApplicationModule),
    typeof(AbpDddWithEfCoreDomainTestModule)
    )]
public class AbpDddWithEfCoreApplicationTestModule : AbpModule
{

}
