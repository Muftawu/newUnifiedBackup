using System.Security.Claims;
namespace Utils;

public static class CommonObjects
{

    public static List<string> Genders = new List<string>()
    {
        "Male",
        "Female"
    };
}

public class UserObj
{
    public string userId { get; set; }
    public string userEmail { get; set; }
    public string userType { get; set; }
    public ClaimsPrincipal _currentUser { get; set; }
}



