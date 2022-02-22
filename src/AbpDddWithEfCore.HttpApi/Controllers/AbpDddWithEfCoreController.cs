using AbpDddWithEfCore.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpDddWithEfCore.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpDddWithEfCoreController : AbpControllerBase
{
    protected AbpDddWithEfCoreController()
    {
        LocalizationResource = typeof(AbpDddWithEfCoreResource);
    }
}
