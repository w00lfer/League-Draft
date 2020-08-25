using System;
using LeagueDraft_API.Enums;

namespace LeagueDraft_API.Helpers
{
    public static class RiotRegionFactory
    {
        public static string GetRiotRegion(RiotRegionEnum riotRegionEnum) =>
            riotRegionEnum switch
            {
                RiotRegionEnum.BR => "br1",
                RiotRegionEnum.EUNE => "eun1",
                RiotRegionEnum.EUW => "euw1",
                RiotRegionEnum.JP => "jp1",
                RiotRegionEnum.KR => "kr",
                RiotRegionEnum.LA1 => "la1",
                RiotRegionEnum.LA2 => "la2",
                RiotRegionEnum.NA => "na1",
                RiotRegionEnum.OC => "oc1",
                RiotRegionEnum.TR => "tr1",
                RiotRegionEnum.RU => "ru",
                _ => throw new Exception("There is no such region")
            };
    }
}
