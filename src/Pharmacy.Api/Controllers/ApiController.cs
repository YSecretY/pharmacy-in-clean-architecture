using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Pharmacy.Api.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count is 0) return Problem();

        if (errors.All(error => error.Type is ErrorType.Validation)) return ValidationProblem(errors);

        return Problem(errors.First());
    }

    protected IActionResult Problem(Error error)
    {
        int statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, detail: error.Description);
    }

    protected IActionResult ValidationProblem(List<Error> errors)
    {
        ModelStateDictionary modelStateDictionary = new();
        errors.ForEach(err => modelStateDictionary.AddModelError(err.Code, err.Description));
        return ValidationProblem(modelStateDictionary);
    }
}