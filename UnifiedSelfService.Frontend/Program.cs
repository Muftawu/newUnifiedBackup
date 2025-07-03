using frontend.Components;
using Blazored.LocalStorage;
using Frontend.Services;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddAuthentication();
builder.Services.AddAuthentication().AddScheme<CustomAuthenticationSchemeOptions, CustomAuthenticationHandler>("JWTAuth", options => { });
builder.Services.AddSingleton<JwtSecurityTokenHandler>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5161") });  

// built-in services
builder.Services.AddAuthorizationCore();
builder.Services.AddAuthorization();
builder.Services.AddLogging();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCascadingAuthenticationState();
builder.Logging.SetMinimumLevel(LogLevel.Information); 

// form states
builder.Services.AddScoped<NewRequestFormState>();

// custom services
builder.Services.AddSingleton<MessageService>();
builder.Services.AddHttpClient<ApiService>();
builder.Services.AddHttpClient<SISAPIService>();
builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<SISAPIService>();
builder.Services.AddScoped<CookieService>();
builder.Services.AddScoped<AccessTokenService>();
builder.Services.AddScoped<CustomAuthenticationStateProviderJWT>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthenticationStateProviderJWT>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
