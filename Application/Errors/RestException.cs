using System;
using System.Net;
using JetBrains.Annotations;

namespace Application.Errors
{
    [UsedImplicitly]
    public class RestException: Exception
    {
        public readonly HttpStatusCode Code;
        public readonly object Errors;

        public RestException(HttpStatusCode code, object errors = null)
        {
            Code = code;
            Errors = errors;
        }
    }
}
