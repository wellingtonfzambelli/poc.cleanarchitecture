using FluentValidation.Results;

namespace CleanArchitecture.Application.Shared;

public abstract class ErrorBaseResponseDto
{
    private IList<ErrorResponseDto> Errors;

    public ErrorBaseResponseDto() =>
        Errors = new List<ErrorResponseDto>();

    public void AddErrorValidationResult(ValidationResult validation)
    {
        foreach (ValidationFailure item in validation.Errors)
            Errors.Add(new ErrorResponseDto(item.PropertyName, item.ErrorMessage));
    }

    public void SetError(ErrorResponseDto error) =>
        Errors.Add(error);

    public void SetErrors(IList<ErrorResponseDto> errors)
    {
        foreach (ErrorResponseDto error in errors)
            Errors.Add(error);
    }

    public bool IsValid() =>
        !Errors.Any();

    public IList<ErrorResponseDto> GetErrors() =>
        Errors;
}