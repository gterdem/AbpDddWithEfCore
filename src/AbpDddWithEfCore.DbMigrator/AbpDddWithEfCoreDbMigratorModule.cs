using AbpDddWithEfCore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpDddWithEfCore.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpDddWithEfCoreEntityFrameworkCoreModule),
    typeof(AbpDddWithEfCoreApplicationContractsModule)
    )]
public class AbpDddWithEfCoreDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
