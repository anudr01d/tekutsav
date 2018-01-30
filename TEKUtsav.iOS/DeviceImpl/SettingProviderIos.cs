using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TEKUtsav.Infrastructure.Settings;
using Foundation;

namespace TEKUtsav.iOS.DeviceImpl
{
    public class SettingProviderIos : ISettings
    {
        private readonly object _locker = new object();

        public SettingProviderIos()
        {
        }

        public void SaveSetting(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key must have a value", "key");

            lock (_locker)
            {
                var defaults = NSUserDefaults.StandardUserDefaults;
                defaults.SetString(value, key);
                defaults.Synchronize();
            }
        }

        //Code found here https://github.com/Cheesebaron/Cheesebaron.MvxPlugins/blob/master/Settings/Cheesebaron.MvxPlugins.Settings.Touch/Settings.cs
        public string GetSetting(string key, string defaultValue = null)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key must have a value", "key");

            lock (_locker)
            {
                var defaults = NSUserDefaults.StandardUserDefaults;
                var valueForKey = defaults.StringForKey(key);
                if (!string.IsNullOrWhiteSpace(valueForKey))
                {
                    var value = valueForKey;
                    return !string.IsNullOrWhiteSpace(value) ? value : defaultValue;
                }
                return defaultValue;
            }
        }

        public void DeleteSetting(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key must have a value", "key");

            lock (_locker)
            {
                var defaults = NSUserDefaults.StandardUserDefaults;
                defaults.RemoveObject(key);
                defaults.Synchronize();
            }
        }
    }
}