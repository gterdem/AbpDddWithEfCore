using AbpDddWithEfCore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpDddWithEfCore.Permissions;

public class AbpDddWithEfCorePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpDddWithEfCorePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpDddWithEfCorePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpDddWithEfCoreResource>(name);
    }
}
