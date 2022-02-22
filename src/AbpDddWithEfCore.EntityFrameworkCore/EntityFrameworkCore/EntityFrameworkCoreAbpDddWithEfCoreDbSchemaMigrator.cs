using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpDddWithEfCore.Data;
using Volo.Abp.DependencyInjection;

namespace AbpDddWithEfCore.EntityFrameworkCore;

public class EntityFrameworkCoreAbpDddWithEfCoreDbSchemaMigrator
    : IAbpDddWithEfCoreDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAbpDddWithEfCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AbpDddWithEfCoreDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AbpDddWithEfCoreDbContext>()
            .Database
            .MigrateAsync();
    }
}
