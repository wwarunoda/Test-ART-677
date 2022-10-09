using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstractions
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogInfo(string apiEndPoint, string param);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
