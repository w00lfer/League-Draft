using System.Collections.Generic;
using System.Text;

namespace LeagueDraft_API.Extensions
{
    public static class StringExtensions
    {
        public static string AppendQueryParametersToUrl(this string url,
            params KeyValuePair<string, string>[] queryParameters)
        {
            var first = true;
            var sb = new StringBuilder(url);
            foreach (var keyValuePair in queryParameters)
            {
                if (first)
                {
                    sb.Append($"?{keyValuePair.Key}={keyValuePair.Value}");
                    first = false;
                }
                else
                    sb.Append($"&{keyValuePair.Key}={keyValuePair.Value}");
            }

            return sb.ToString();
        }
    }
}
