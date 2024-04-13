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
        if (IsNameExistent(name))
        {
            return UserNameValidity.Exists;
        }
        if(IsNameTooLong(name))
        {
            return UserNameValidity.TooLong;
        }
        if(IsNameTooShort(name))
        {
            return UserNameValidity.TooShort;
        }

        return UserNameValidity.IsValid;
    }

    private static bool IsNameExistent(string name)
    {
        // tady to pošle GET request na server který checke jestli už takové jméno v databázi je
        throw new NotImplementedException();
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