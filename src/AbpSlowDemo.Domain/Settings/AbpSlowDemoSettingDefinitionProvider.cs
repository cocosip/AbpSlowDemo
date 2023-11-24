using Volo.Abp.Settings;

namespace AbpSlowDemo.Settings;

public class AbpSlowDemoSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AbpSlowDemoSettings.MySetting1));
    }
}
