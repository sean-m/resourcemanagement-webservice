﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.ServiceModel.Web;

namespace Lithnet.ResourceManagement.WebService
{
    public static class WebExceptionHelper
    {
        public static Exception CreateWebException(HttpStatusCode code)
        {
            return WebExceptionHelper.CreateWebException(code, null, null);
        }

        public static Exception CreateWebException(HttpStatusCode code, Exception ex)
        {
            return WebExceptionHelper.CreateWebException(code, ex, null);
        }

        public static Exception CreateWebException(HttpStatusCode code, Exception ex, string details)
        {
            if (ex != null)
            {
                ExceptionData data = new ExceptionData(ex);
                data.Reason = details;
                return new WebFaultException<ExceptionData>(data, code);
            }
            else
            {
                return new WebFaultException(code);
            }
        }
    }
}