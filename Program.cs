using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

int? localhostHTTPSport = null;
if (app.Environment.IsDevelopment())
{
    localhostHTTPSport = Int32.Parse(
    Environment.GetEnvironmentVariable("ASPNETCORE_URLS")!.Split(new Char[] { ':', ';' })[2]);
}

var options = new RewriteOptions()
      .AddRedirectToHttps(301, localhostHTTPSport);

app.UseRewriter(options);

app.MapGet("/", () => "Hello World!");

app.Run();
