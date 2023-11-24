using AbpSlowDemo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpSlowDemo.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpSlowDemoController : AbpControllerBase
{
    protected AbpSlowDemoController()
    {
        LocalizationResource = typeof(AbpSlowDemoResource);
    }
}
