namespace CleanArchitecture.Infrastructure.Shared;

public static class MessageValidation
{
    // Globals
    public static (string Code, string Description) GeneralError { get; } = ("CA999", "Something was wrong. Try again later.");

    // FluentValidation
    public static (string Code, string Description) DateLessThan { get; } = ("CA002", "Date can not be less than 2020-01-01");
    public static (string Code, string Description) NoDataFound { get; } = ("CA003", "Empty list");
    public static (string Code, string Description) RequiredField { get; } = ("CA004", "The field {0} is required");
    public static (string Code, string Description) InvalidField { get; } = ("CA005", "The field {0} is invalid");
    public static (string Code, string Description) InvalidMaxlength { get; } = ("CA006", "The field {0} should contains at maximun {1}");
    public static (string Code, string Description) InvalidMinlength { get; } = ("CA007", "The field {0} should contains at minimum {1}");
    public static (string Code, string Description) NotEqual { get; } = ("CA008", "The field {0} does not match with the field {1}");

    // Auth
    public static (string Code, string Description) AuthUserIsLockedOut { get; } = ("CA050", "This account is locked out");
    public static (string Code, string Description) AuthUserIsNowAllowed { get; } = ("CA051", "This account does not have permition to login");
    public static (string Code, string Description) AuthUserRequiresTwoFactors { get; } = ("CA052", "It is necessary to confirm in your the second factor");
    public static (string Code, string Description) AuthUserOrPasswordInvalid { get; } = ("CA053", "E-mail or password invalid");
    public static (string Code, string Description) AuthUserNotFound { get; } = ("CA054", "User not found");
    public static (string Code, string Description) AuthEmailNotConfirmed { get; } = ("CA055", "E-mail not confirmed");
    public static (string Code, string Description) AuthSignupFail { get; } = ("CA056", string.Empty);
}