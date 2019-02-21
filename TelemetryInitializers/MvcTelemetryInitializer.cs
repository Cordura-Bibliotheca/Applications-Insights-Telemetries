using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace TelemetryInitializers
{
    public class MvcTelemetryInitializer : ITelemetryInitializer
    {

        /// <summary>
        /// Initializes properties of the specified 
        /// <see cref="T:Microsoft.ApplicationInsights.Channel.ITelemetry" /> object.
        /// </summary>
        /// <param name="telemetry">the telemetry channel</param>
        public void Initialize(ITelemetry telemetry)
        {
            var requestTelemetry = telemetry as RequestTelemetry;
            if (requestTelemetry != null && (HttpContext.Current.Request.HttpMethod.Equals(HttpMethod.Post.ToString()) || HttpContext.Current.Request.HttpMethod.Equals(HttpMethod.Put.ToString())))
            {

                if (!requestTelemetry.Properties.ContainsKey("body"))
                {
                    var inputStream = HttpContext.Current.Request.InputStream;

                    inputStream.Position = 0;
                    using (var reader = new StreamReader(inputStream))
                    {
                        string requestBody = reader.ReadToEnd();
                        requestTelemetry.Properties.Add("body", requestBody);
                    }
                }

                if (!requestTelemetry.Properties.ContainsKey("IP"))
                {
                    requestTelemetry.Properties.Add("IP", GetIP());
                }
            }
        }

        public static String GetIP()
        {
            String ip =
                HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return ip;
        }
    }
}