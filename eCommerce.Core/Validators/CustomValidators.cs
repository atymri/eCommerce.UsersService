namespace eCommerce.Core.Validators;

public static class CustomValidators
{
    public static bool BeValidEmail(string email)
    {
        var validDomains = new List<string> { "gmail.com", "yahoo.com", "outlook.com" };
        var emailDomain = email.Split('@').Last();
        return validDomains.Contains(emailDomain);
    }

    public static bool BeValidPhone(string phoneNumber)
    {
        var validPrefixes = "09";
        var phonePrefix = phoneNumber.Substring(0, 2);
        return validPrefixes.Equals(phonePrefix);
    }
}

