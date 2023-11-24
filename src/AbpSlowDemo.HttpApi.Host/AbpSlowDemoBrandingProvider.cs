using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpSlowDemo;

[Dependency(ReplaceServices = true)]
public class AbpSlowDemoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpSlowDemo";
}
