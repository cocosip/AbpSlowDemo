using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpSlowDemo.Data;

/* This is used if database provider does't define
 * IAbpSlowDemoDbSchemaMigrator implementation.
 */
public class NullAbpSlowDemoDbSchemaMigrator : IAbpSlowDemoDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
