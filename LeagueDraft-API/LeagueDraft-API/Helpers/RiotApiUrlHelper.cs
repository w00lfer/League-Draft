using System.Collections.Generic;
using LeagueDraft_API.Enums;
using LeagueDraft_API.Extensions;

namespace LeagueDraft_API.Helpers
{
    public static class RiotApiUrlHelper
    {
        private const string BaseUrl = "api.riotgames.com/lol";

        public static string GetUrl(RiotRegionEnum riotRegionEnum, string endPoint, string requiredValue, params KeyValuePair<string, string>[] queryParameters)
        {
            var region = RiotRegionFactory.GetRiotRegion(riotRegionEnum);
            var url = $"Https://{region}.{BaseUrl}/{endPoint}/{requiredValue}";
            if (queryParameters.Length != 0) url = url.AppendQueryParametersToUrl(queryParameters);
            return url;
        }
    }
}
