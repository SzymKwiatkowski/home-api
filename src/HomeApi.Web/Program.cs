using HomeApi.Application;
using HomeApi.Infrastructure;
using HomeApi.Infrastructure.Data;
using HomeApi.Web;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddKeyVaultIfConfigured();

builder.AddApplicationServices();

builder.AddInfrastructureServices();

builder.AddWebServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

    app.UseHsts();
}

app.UseHealthChecks("/health");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseExceptionHandler(options => { });

app.UseCors(static builder => 
    builder.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin());

app.MapOpenApi();

app.UseSwaggerUI(settings =>
{
    settings.SwaggerEndpoint("/openapi/v1.json", "v1");
});

app.UseReDoc(options =>
{
    options.SpecUrl("/openapi/v1.json");
    options.RoutePrefix = "docs";
});

app.MapScalarApiReference();

app.Map("/", () => Results.Redirect("/scalar"));

app.MapEndpoints(typeof(Program).Assembly);

await app.RunAsync();

namespace HomeApi.Web
{
    public partial class Program { }
}
