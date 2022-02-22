using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpDddWithEfCore.Data;

/* This is used if database provider does't define
 * IAbpDddWithEfCoreDbSchemaMigrator implementation.
 */
public class NullAbpDddWithEfCoreDbSchemaMigrator : IAbpDddWithEfCoreDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
