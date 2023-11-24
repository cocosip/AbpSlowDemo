using AbpSlowDemo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpSlowDemo.Permissions;

public class AbpSlowDemoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpSlowDemoPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpSlowDemoPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpSlowDemoResource>(name);
    }
}
