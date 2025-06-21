using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;

namespace SecretAPI;

public class SteamJsonParser
{
    public async Task<JsonResult> ParseSkins(string json)
    {
        var jsonNode = JsonNode.Parse(json);
        var jsonArray = jsonNode["results"]!.AsArray();
        List<SkinInfo> skinInfos = new List<SkinInfo>();
        foreach (var node in jsonArray)
        {
            if (node != null)
            {
                SkinInfo skinInfo = new SkinInfo
                {
                    Name = node["name"]?.ToString(),
                    Price = node["sell_price_text"]?.ToString(),
                    Count = node["sell_listings"]?.GetValue<int>(),
                    ImageUrl = node["asset_description"]?["icon_url"]?.ToString(),
                    MarketUrl = $"https://steamcommunity.com/market/listings/570/{node["hash_name"]?.ToString()}" // Construct the market URL
                };
                skinInfos.Add(skinInfo);
            }
        }
        return new JsonResult(skinInfos);
    }
}