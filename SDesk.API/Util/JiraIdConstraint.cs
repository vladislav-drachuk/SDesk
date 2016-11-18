using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http.Routing;

namespace SDesk.API.Util
{
    public class JiraIdConstraint: IHttpRouteConstraint
    {
        private readonly string _regEx = @"Jira-\d+";

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName,
            IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            object value;
            values.TryGetValue(parameterName, out value);
            string pattern = "^(" + _regEx + ")$";
            string input = Convert.ToString(
                value, CultureInfo.InvariantCulture);

            var result = Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            return result;
        }
    }
}