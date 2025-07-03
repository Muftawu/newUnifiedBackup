using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Services;

public class AccessTokenService
{
    private readonly CookieService _cookieService;
    private readonly string key = "token";

    public AccessTokenService(CookieService cookieService)
    {
        _cookieService = cookieService;
    }

    public async Task SetToken(string token)
    {
        await _cookieService.Set(key, token, 1);
    }

    public async Task<string> GetToken() 
    {
        return await _cookieService.Get(key);
    }

    public async Task RemoveToken()
    {
        await _cookieService.Remove(key);
    }
}
