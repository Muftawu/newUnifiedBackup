using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using System.Text.Json;
using Blazored.LocalStorage;

namespace Frontend.Services;

public class CustomAuthenticationStateProviderJWT : AuthenticationStateProvider
{
    private AuthenticationState _authenticationState;
    private readonly ILocalStorageService _localStorage;
    private readonly AccessTokenService _accessTokenService;
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

    public CustomAuthenticationStateProviderJWT(ILocalStorageService localStorage, JwtSecurityTokenHandler jwtSecurityTokenHandler, AccessTokenService accessTokenService)
    {
        _localStorage = localStorage;
        _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
        _accessTokenService = accessTokenService;
        _authenticationState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try {
                var user = new ClaimsPrincipal(new ClaimsIdentity());
                var tokenPresent = await _accessTokenService.GetToken();
                if (tokenPresent == null) 
                { 
                    return new AuthenticationState(user); 
                }
                var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(tokenPresent);

                if (tokenContent.ValidTo < DateTime.Now)
                {
                    await _accessTokenService.RemoveToken();
                    return new AuthenticationState(user);
                }
        
                var claims = await GetClaimsAsync();
                user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
                return new AuthenticationState(user);

            }
            catch (Exception e) {
                return new AuthenticationState(new ClaimsPrincipal());
            }
    }

    private async Task<List<Claim>> GetClaimsAsync()
    {
        var token = await _accessTokenService.GetToken();
        var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(token);
        var claims = tokenContent.Claims.ToList();
        claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
        return claims;
    }

    public async Task<bool> IsUserAuthenticated()
    {
        var token = await _accessTokenService.GetToken();
        if (token == null) return false;
        return true;
    }

    public async Task MarkUserAsAuthenticated(string token)
    {
        await _accessTokenService.SetToken(token);
        var claims = await GetClaimsAsync();
        var user = new ClaimsPrincipal(new  ClaimsIdentity(claims, "jwt"));
        var authState = Task.FromResult(new AuthenticationState(user));
        NotifyAuthenticationStateChanged(authState);
    }

    public async Task MarkUserAsLoggedOut()
    {
        await _accessTokenService.RemoveToken();
        var loggedOutUser = new ClaimsPrincipal(new ClaimsIdentity());
        var authState = Task.FromResult(new AuthenticationState(loggedOutUser));
        NotifyAuthenticationStateChanged(authState);
    }
}
