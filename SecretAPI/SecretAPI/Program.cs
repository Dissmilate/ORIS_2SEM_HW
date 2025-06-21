using System.Net;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SecretAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/get-smots", async (int count = 2) =>
{
    string[] heroes = new[] { "morphling", "arc_warden"};
    HttpClient client = new HttpClient();
    List<JsonResult> list = new List<JsonResult>();
    SteamJsonParser steamJsonParser = new SteamJsonParser();
    foreach (var hero in heroes)
    {
        Uri steamMarketPlaceUri =
            new Uri($"https://steamcommunity.com/market/search/render/?query=&start=0&count={count}&" +
                    $"appid=570&category_570_Hero[]=tag_npc_dota_hero_{hero}&norender=1");
        var response = await client.GetAsync(steamMarketPlaceUri);
        var content = await response.Content.ReadAsStringAsync();
        var json = await steamJsonParser.ParseSkins(content);
        list.Add(json);
    }
    JsonResult result = new JsonResult(list[0], list[1]);
    Console.WriteLine(list.Count);
    return result;
});

app.Run();

