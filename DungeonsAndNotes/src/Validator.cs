using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace DungeonsAndNotes;

public static class Validator
{

    private static int _nameMaxLenght = 20;
    private static int _nameMinLenght = 2;
    public enum UserNameValidity
    {
        IsValid,
        Exists,
        TooLong,
        TooShort
    }
    public static UserNameValidity ValidateUserName(string name)
    {
        if(IsNameTooLong(name))
        {
            return UserNameValidity.TooLong;
        }
        if(IsNameTooShort(name))
        {
            return UserNameValidity.TooShort;
        }
        if (IsNameExistent(name).Result)
        {
            return UserNameValidity.Exists;
        }

        return UserNameValidity.IsValid;
    }

    private static async Task<bool> IsNameExistent(string name)
    {
        // tady to pošle POST request na server který checke jestli už takové jméno v databázi je
        
        var registertationInfo = new Dictionary<string, string>()
        {
            {
                "username", name
            },
        };
        
        var jsonString = JsonSerializer.Serialize(registertationInfo);
        StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
        
        var response = await Connection.GetConnection().Client.PostAsync("http://127.0.0.1:80/exists/name", stringContent);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }

        Console.WriteLine(response);
        return false;

    }

    private static bool IsNameTooLong(string name)
    {
        return name.Length > _nameMaxLenght;
    }

    private static bool IsNameTooShort(string name)
    {
        return name.Length < _nameMinLenght;
    }

    private static int _passwordMinLength = 8;
    public enum PasswordValidity
    {
        IsValid,
        TooShort,
        DontMatch
    }

    public static PasswordValidity ValidatePassword(string password, string? confirmPassword = null)
    {
        if (IsPasswordTooShort(password))
        {
            return PasswordValidity.TooShort;
        }

        if (IsPasswordMatching(password, confirmPassword))
        {
            return PasswordValidity.DontMatch;
        }

        return PasswordValidity.IsValid;
    }

    private static bool IsPasswordTooShort(string password)
    {
        return password.Length < _passwordMinLength;
    }

    private static bool IsPasswordMatching(string password, string? confirmPassword)
    {
        return password.Equals(confirmPassword);
    }
}