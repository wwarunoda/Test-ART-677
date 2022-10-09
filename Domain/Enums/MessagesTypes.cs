using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum MessageTypes
    {
        Success,
        No_Data_Found
    }

    public static class MessageTypesExtensions
    {
        public static String AsText(this MessageTypes messageTypes)
        {
            switch (messageTypes)
            {
                case MessageTypes.Success: return "Success";
                case MessageTypes.No_Data_Found: return "Not_Found";
                default: return String.Empty;
            }
        }
    }
}
