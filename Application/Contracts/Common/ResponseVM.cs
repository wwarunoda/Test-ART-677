using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Common
{
    public class ResponseVM<T>
    {
        public string Message { get; set; } = "Success";
        public T Data { get; set; }
    }
}
