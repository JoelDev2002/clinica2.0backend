using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public class GlobalExceptionHandler : IExceptionHandler
{
  public async ValueTask<bool> TryHandleAsync(
    HttpContext httpContext,
    Exception exception,
    CancellationToken cancellationToken)
  {

    var (statusCode,title) =exception switch
    {
      NotFoundException => (StatusCodes.Status404NotFound,"No encontrado"),
      ConflictException => (StatusCodes.Status409Conflict,"Ocurrio un conflicto"),
      BadRequestException => (StatusCodes.Status400BadRequest,"Solicitd Erronea"),
      _=> (StatusCodes.Status500InternalServerError,"Error del servidor")
    };

    var problemDetails=new ProblemDetails
    {
      
      Title= title,
      Status= statusCode,
      Detail=exception.Message
    };

    httpContext.Response.StatusCode=statusCode;
    await httpContext.Response.WriteAsJsonAsync(problemDetails);
    
    return true;
  }
}