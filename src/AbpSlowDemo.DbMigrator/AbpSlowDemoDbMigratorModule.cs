using AbpSlowDemo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbpSlowDemo.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpSlowDemoEntityFrameworkCoreModule),
    typeof(AbpSlowDemoApplicationContractsModule)
    )]
public class AbpSlowDemoDbMigratorModule : AbpModule
{
}
