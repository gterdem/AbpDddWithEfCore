using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace AbpDddWithEfCore.Web;

[Dependency(ReplaceServices = true)]
public class AbpDddWithEfCoreBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpDddWithEfCore";
}
