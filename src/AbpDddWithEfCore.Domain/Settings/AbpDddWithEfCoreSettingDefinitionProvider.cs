using Volo.Abp.Settings;

namespace AbpDddWithEfCore.Settings;

public class AbpDddWithEfCoreSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AbpDddWithEfCoreSettings.MySetting1));
    }
}
