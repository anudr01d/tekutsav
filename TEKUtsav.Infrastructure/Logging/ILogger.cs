using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEKUtsav.Infrastructure.Logging
{
    public interface ILogger
    {
        Task<bool> ShipLogsToServerAsync();
        Task LogErrorAsync(Exception ex);
        Task LogUnhandledExceptionAsync(Exception ex);
        Task LogInfoAsync(string logText, Severity severity = Severity.Info);
    }
}
