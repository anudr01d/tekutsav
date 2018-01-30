using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TEKUtsav.Infrastructure.Settings;
using Android.Preferences;

namespace TEKUtsav.Droid.DeviceImpl
{
    public class SettingProviderDroid : ISettings
    {
        private readonly object _locker = new object();
        private static string _settingsFileName;

        private static ISharedPreferences SharedPreferences
        {
            get
            {
                var context = Application.Context;

                //If file name is empty use defaults 
                if (string.IsNullOrEmpty(_settingsFileName))
                    return PreferenceManager.GetDefaultSharedPreferences(context);

                return context.ApplicationContext.GetSharedPreferences(_settingsFileName, FileCreationMode.Append);
            }
        }

        public SettingProviderDroid()
        {

        }

        public string GetSetting(string key, string defaultValue = null)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key must have a value", "key");

            lock (_locker)
            {
                string returnVal;
                using (var sharedPrefs = SharedPreferences)
                {
                    var encrypted = sharedPrefs.GetString(key, "none");
                    if (!string.IsNullOrWhiteSpace(encrypted))
                    {
                        if (encrypted == "none")
                        {
                            returnVal = defaultValue;
                        }
                        else
                        {
                            //var decryptedValue = _cryptographyHelper.Decrypt(encrypted);
                            //returnVal = !string.IsNullOrWhiteSpace(decryptedValue) ? decryptedValue : defaultValue;
                            returnVal = !string.IsNullOrWhiteSpace(encrypted) ? encrypted : defaultValue;
                        }
                    }
                    else
                    {
                        returnVal = defaultValue;
                    }
                }
                return returnVal;
            }
        }

        public void SaveSetting(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key must have a value", "key");

            lock (_locker)
            {
                using (var sharedPrefs = SharedPreferences)
                {
                    using (var editor = sharedPrefs.Edit())
                    {
                        //var encrypted = _cryptographyHelper.Encrypt(value);
                        //editor.PutString(key, Convert.ToString(encrypted));

                        editor.PutString(key, Convert.ToString(value));
                        editor.Commit();
                    }
                }
            }
        }


        public void DeleteSetting(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key must have a value", "key");

            lock (_locker)
            {
                using (var sharedPrefs = SharedPreferences)
                {
                    using (var editor = sharedPrefs.Edit())
                    {
                        editor.Remove(key);
                        editor.Commit();
                    }
                }
            }
        }
    }
}