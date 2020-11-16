using System.Configuration;

namespace EntityGenerator.Settings
{
    public class AutoEntitySettings : ApplicationSettingsBase
    {
        [UserScopedSetting]
        [DefaultSettingValue("temp")]
        public string EntityTemplate { get; set; }
    }
}
