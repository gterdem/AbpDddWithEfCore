using AbpDddWithEfCore.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpDddWithEfCore;

[DependsOn(
    typeof(AbpDddWithEfCoreEntityFrameworkCoreTestModule)
    )]
public class AbpDddWithEfCoreDomainTestModule : AbpModule
{

}
