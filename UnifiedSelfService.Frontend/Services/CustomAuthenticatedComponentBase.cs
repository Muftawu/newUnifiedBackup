using Microsoft.AspNetCore.Components;
using Frontend.Services;

public class CustomAuthenticatedComponentBase : ComponentBase
{
    [Inject] protected CustomAuthenticationStateProviderJWT? CustomAuthenticationStateProviderJWT { get; set; }
    [Inject] protected NavigationManager? NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var authState = await CustomAuthenticationStateProviderJWT!.GetAuthenticationStateAsync();
        var user = authState.User;

        if (!user.Identity?.IsAuthenticated ?? true)
        {
            Console.WriteLine("user nto logged in ");
            NavigationManager?.NavigateTo("/login", true);
        }
    }
}
