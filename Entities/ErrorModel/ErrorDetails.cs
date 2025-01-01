using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entities.ErrorModel
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        // ع يرجع الموديل دة فى الريسبونس على هيئة   جيسون 
        public override string ToString() =>  JsonSerializer.Serialize(this);
       
    }
}
