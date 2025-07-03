using System;
using Microsoft.JSInterop;

namespace Frontend.Services;

public class CookieService
{
    private readonly IJSRuntime _jsruntime;

    public CookieService(IJSRuntime jsruntime)
    {
        _jsruntime = jsruntime;
    }

    public async Task Set(string key, string token, int days)
    {
        await _jsruntime.InvokeVoidAsync("setCookie", key, token, days);
    }

    public async Task<string> Get(string key)
    {
        return await _jsruntime.InvokeAsync<string>("getCookie", key);
    }

    public async Task Remove(string key)
    {
        await _jsruntime.InvokeVoidAsync("deleteCookie", key);
    }
    
    public async Task<string> GetFormFieldData(string fieldId)
    {
        Console.WriteLine($"field id is {fieldId}");
        var data = await _jsruntime.InvokeAsync<string>("getFormFieldData", fieldId);
        Console.WriteLine($"data is {data}");
        return data;
    }

}
