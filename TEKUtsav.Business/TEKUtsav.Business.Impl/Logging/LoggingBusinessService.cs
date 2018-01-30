using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using TEKUtsav.Infrastructure.Logging;
using TEKUtsav.Infrastructure.Settings;

namespace TEKUtsav.Business.Impl
{
    public class LoggingBusinessService : ILogger
    {
        private readonly ISettings _settings;
        const string LOGGED = "Logged";

        public LoggingBusinessService(ISettings settings)
        {
            //if (loggingStore == null) throw new ArgumentNullException("loggingStore");
            if (settings == null) throw new ArgumentNullException("settings");
            //_loggingStore = loggingStore;
            _settings = settings;
        }

        public async Task LogErrorAsync(Exception ex)
        {
            if (CanLog(ex))
            {
               // var logItem = BuildLogItem(ex, Severity.Error);
                //await _loggingStore.LogAsync(logItem);
            }
            else
            {
               await Task.Run(() => { });
            }
        }

        public Task LogInfoAsync(string logText, Severity severity = Severity.Info)
        {
            //var logItem = BuildLogItem(logText, severity);
            //return _loggingStore.LogAsync(logItem);
            return Task.Run(() => { });
        }

        public Task<bool> ShipLogsToServerAsync()
        {
            //return _loggingStore.ShipLogsToServer();
            return Task.Run(() => { return true;  });

        }

      

        private bool CanLog(Exception ex)
        {
            return !ex.Data.Contains(LOGGED);
        }

        public Task LogUnhandledExceptionAsync(Exception ex)
        {
			return Task.Run(() => { 
				Debug.WriteLine(ex.ToString());
			});
        }
    }
}
