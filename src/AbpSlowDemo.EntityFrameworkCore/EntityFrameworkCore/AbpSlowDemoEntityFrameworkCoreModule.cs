using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Uow;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.CmsKit.EntityFrameworkCore;
using Volo.Blogging.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Users.EntityFrameworkCore;
using Kayisoft.Abp.AEManagement.EntityFrameworkCore;
using Kayisoft.Abp.DataQueryManagement.EntityFrameworkCore;
using Kayisoft.Abp.DicomAbnormal.EntityFrameworkCore;
using Kayisoft.Abp.DicomCompression.EntityFrameworkCore;
using Kayisoft.Abp.DicomCompression.Policy.EntityFrameworkCore;
using Kayisoft.Abp.Dicom.Misc.EntityFrameworkCore;
using Kayisoft.Abp.DicomQueryManagement.EntityFrameworkCore;
using Kayisoft.Abp.RISCallbackManagement.EntityFrameworkCore;
using Kayisoft.Abp.RISCallbackBinding.EntityFrameworkCore;
using Kayisoft.Abp.DicomUidsManagement.EntityFrameworkCore;
using Kayisoft.Abp.RISQueryManagement.EntityFrameworkCore;
using Kayisoft.Abp.RISQueryBinding.EntityFrameworkCore;
using SharpAbp.MinId.EntityFrameworkCore;

namespace AbpSlowDemo.EntityFrameworkCore;

[DependsOn(
    typeof(AbpSlowDemoDomainModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCorePostgreSqlModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule),

    typeof(CmsKitEntityFrameworkCoreModule),
    typeof(BloggingEntityFrameworkCoreModule),
    typeof(AbpIdentityServerEntityFrameworkCoreModule),
    typeof(BlobStoringDatabaseEntityFrameworkCoreModule),
    typeof(AbpUsersEntityFrameworkCoreModule),
    
    typeof(AeManagementEntityFrameworkCoreModule),
    typeof(DataQueryManagementEntityFrameworkCoreModule),
    typeof(DicomAbnormalEntityFrameworkCoreModule),
    typeof(DicomCompressionEntityFrameworkCoreModule),
    typeof(DicomCompressionPolicyEntityFrameworkCoreModule),
    typeof(DicomMiscEntityFrameworkCoreModule),
    typeof(DicomQueryManagementEntityFrameworkCoreModule),
    typeof(RisCallbackManagementEntityFrameworkCoreModule),
    typeof(RisCallbackBindingEntityFrameworkCoreModule),
    typeof(RisQueryManagementEntityFrameworkCoreModule),
    typeof(RisQueryBindingEntityFrameworkCoreModule),
    typeof(DicomUidsManagementEntityFrameworkCoreModule),
    typeof(MinIdEntityFrameworkCoreModule)

    )]
public class AbpSlowDemoEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        AbpSlowDemoEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<AbpSlowDemoDbContext>(options =>
        {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
                /* The main point to change your DBMS.
                 * See also AbpSlowDemoMigrationsDbContextFactory for EF Core tooling. */
            options.UseNpgsql();
        });

    }
}
