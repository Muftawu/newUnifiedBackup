using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Frontend.Services;

public class CustomAuthenticationHandler : AuthenticationHandler<CustomAuthenticationSchemeOptions>
{

    private readonly ILocalStorageService _localStorageService;

    public CustomAuthenticationHandler(
        IOptionsMonitor<CustomAuthenticationSchemeOptions> options, 
        ILoggerFactory logger, 
        UrlEncoder encoder, 
        ISystemClock clock, 
        ILocalStorageService localStorage
        ) : base(options, logger, encoder, clock)
    {
        _localStorageService = localStorage;
    }

    protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        try
        {
            var accessTokenResult = Request.Cookies["token"];
            if (string.IsNullOrEmpty(accessTokenResult)) return AuthenticateResult.NoResult();

            var readJWT = new JwtSecurityTokenHandler().ReadJwtToken(accessTokenResult);
            var identity = new ClaimsIdentity(readJWT.Claims, "JWT");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            
            return await Task.FromResult(AuthenticateResult.Success(ticket));
        }
        catch (Exception ex)
        {
            return AuthenticateResult.NoResult();
        }
    }

    protected override Task HandleChallengeAsync(AuthenticationProperties properties)
    {
        Response.Redirect("/login");
        return Task.CompletedTask;
    }


    protected override Task HandleForbiddenAsync(AuthenticationProperties properties)
    {
        Response.Redirect("/accessdenied");
        return Task.CompletedTask;
    }
}


public class CustomAuthenticationSchemeOptions : AuthenticationSchemeOptions
{
}
