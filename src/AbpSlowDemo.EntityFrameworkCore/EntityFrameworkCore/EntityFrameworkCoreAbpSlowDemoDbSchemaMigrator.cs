using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpSlowDemo.Data;
using Volo.Abp.DependencyInjection;

namespace AbpSlowDemo.EntityFrameworkCore;

public class EntityFrameworkCoreAbpSlowDemoDbSchemaMigrator
    : IAbpSlowDemoDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAbpSlowDemoDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the AbpSlowDemoDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AbpSlowDemoDbContext>()
            .Database
            .MigrateAsync();
    }
}
