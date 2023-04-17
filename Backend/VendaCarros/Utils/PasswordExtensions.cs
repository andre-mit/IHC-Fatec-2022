namespace VendaCarros.Utils;

public static class PasswordExtensions
{
    public static string HashPassword(this string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}