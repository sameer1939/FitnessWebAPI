using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FitnessWebAPI.APIErrors
{
    public class ApiError
    {
        public ApiError()
        {

        }
        public ApiError(int errorCode, string errorMessage,string errorDesc)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            ErrorDescription = errorDesc;
        }
        public string ErrorMessage { get; set; }
        public string ErrorDescription { get; set; }
        public int ErrorCode { get; set; }

        public override string ToString()
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return JsonSerializer.Serialize(this, options);
        }

    }
}
