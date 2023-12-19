namespace NewProductManagement.Models;

public class TokenManager
{
    private static string _jwtToken;

    public static void SetToken(string token)
    {
        _jwtToken = token;
    }

    public static string GetToken()
    {
        return _jwtToken;
    }
}