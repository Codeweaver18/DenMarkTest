using System;
using System.Collections.Generic;
using System.Text;

namespace DenMarkTest.core.Abstract
{
    public static class ResponseCodes
    {
        public static string success { get; } = "00";
        public static string error { get; } = "01";
    }

    public static class ResponseMessages
    {
        public static string success { get; } = "Completed/Approved successfully";
        public static string error { get; } = "error/unsuccessful";
    }
}
