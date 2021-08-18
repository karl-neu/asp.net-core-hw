using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Globalization;

namespace WebApi.Constraints
{
    public class CustomRouteConstraint : IRouteConstraint
    {
        private double _doubleValue;

        public CustomRouteConstraint()
        {
            _doubleValue = 2.5;
        }

        public bool Match(HttpContext httpContext,
            IRouter route,
            string routeKey,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out object value) && value != null)
            {
                var doubleValue = Convert.ToDouble(value, CultureInfo.InvariantCulture);

                if (doubleValue != 0)
                    return doubleValue == _doubleValue;
            }

            return false;
        }
    }
}