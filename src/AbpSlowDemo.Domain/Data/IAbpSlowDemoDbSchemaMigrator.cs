using System.Threading.Tasks;

namespace AbpSlowDemo.Data;

public interface IAbpSlowDemoDbSchemaMigrator
{
    Task MigrateAsync();
}
