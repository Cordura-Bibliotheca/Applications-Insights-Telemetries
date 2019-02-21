using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TelemetryInitializers
{

    public class WcfTelemetryInitializer : ITelemetryInitializer
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
                if (!requestTelemetry.Properties.ContainsKey("body") && HttpContext.Current.Items.Contains("requestBody"))
                {
                    string res = (string)HttpContext.Current.Items["requestBody"];
                    requestTelemetry.Properties.Add("body", res);
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
