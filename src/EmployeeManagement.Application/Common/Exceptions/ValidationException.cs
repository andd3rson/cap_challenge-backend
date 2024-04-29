using FluentValidation.Results;

namespace EmployeeManagement.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException()
        : base("one or more validation errors occurred.")
    { }

    public ValidationException(List<ValidationFailure> failures)
        : this()
    {
        var propertyNames = failures
            .Select(e => e.PropertyName)
            .Distinct();

        foreach (var propertyName in propertyNames)
        {
            var propertyFailures = failures
                .Where(e => e.PropertyName == propertyName)
                .Select(e => e.ErrorMessage)
                .ToArray();

            Errors.Add(propertyName, propertyFailures);
        }
    }

    public IDictionary<string, string[]> Errors { get; }
        = new Dictionary<string, string[]>();
}
