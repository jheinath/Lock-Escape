using System.Globalization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace LockEscape;

public static class WebAssemblyHostExtensions
{
    public static async Task SetDefaultCulture(this WebAssemblyHost host)
    {
        var localStorage = host.Services.GetRequiredService<ILocalStorageService>();
        var cultureString = await localStorage.GetItemAsync<string>("culture");
        
        var cultureInfo = !string.IsNullOrWhiteSpace(cultureString) 
            ? new CultureInfo(cultureString) 
            : new CultureInfo("en-GB");
        
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
    }
}