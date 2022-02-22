using System;
using System.Collections.Generic;
using System.Text;
using AbpDddWithEfCore.Localization;
using Volo.Abp.Application.Services;

namespace AbpDddWithEfCore;

/* Inherit your application services from this class.
 */
public abstract class AbpDddWithEfCoreAppService : ApplicationService
{
    protected AbpDddWithEfCoreAppService()
    {
        LocalizationResource = typeof(AbpDddWithEfCoreResource);
    }
}
