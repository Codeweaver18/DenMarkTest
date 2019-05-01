using DenMarkTest.core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DenMarkTest.core.Responses
{
    public class response
    {
        public string responseCode { get; set; } = ResponseCodes.error;
        public string responseMessage { get; set; } = ResponseMessages.error;
        public string responseDescription { get; set; } = string.Empty;
        public object responseObject { get; set; }
    }
}
