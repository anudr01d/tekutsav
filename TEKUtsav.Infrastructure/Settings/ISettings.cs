namespace TEKUtsav.Infrastructure.Settings
{
    public interface ISettings
    {
        string GetSetting(string key, string defaultValue = null);
        void SaveSetting(string key, string value);
        void DeleteSetting(string key);
    }
}