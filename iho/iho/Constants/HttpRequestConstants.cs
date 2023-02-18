using System;
using System.Collections.Generic;
using System.Text;

namespace iho.Constants
{
    public static class HttpRequestConstants
    {
        public static readonly string BaseApiAddress = "https://localhost:5001/api/";
        public static readonly string AuthentitcateEndpoint = "Account/Login";
        public static readonly string RegistrationEndpoint = "Account/Register";
    }
}
