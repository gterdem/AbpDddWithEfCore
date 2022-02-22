using System.Threading.Tasks;

namespace AbpDddWithEfCore.Data;

public interface IAbpDddWithEfCoreDbSchemaMigrator
{
    Task MigrateAsync();
}
