using System;
using System.Collections.Generic;
using System.Text;
using AbpSlowDemo.Localization;
using Volo.Abp.Application.Services;

namespace AbpSlowDemo;

/* Inherit your application services from this class.
 */
public abstract class AbpSlowDemoAppService : ApplicationService
{
    protected AbpSlowDemoAppService()
    {
        LocalizationResource = typeof(AbpSlowDemoResource);
    }
}
