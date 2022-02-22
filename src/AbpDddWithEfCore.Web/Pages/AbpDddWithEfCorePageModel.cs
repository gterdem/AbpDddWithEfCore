using AbpDddWithEfCore.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpDddWithEfCore.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class AbpDddWithEfCorePageModel : AbpPageModel
{
    protected AbpDddWithEfCorePageModel()
    {
        LocalizationResourceType = typeof(AbpDddWithEfCoreResource);
    }
}
