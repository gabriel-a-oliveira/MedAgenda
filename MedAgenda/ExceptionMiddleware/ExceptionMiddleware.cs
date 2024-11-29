using System.ComponentModel.DataAnnotations;

namespace MedAgenda.ExceptionMiddleware;

public class ExceptionMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var statusCode = exception switch
        {
            KeyNotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        var mensagem = statusCode switch
        {
            StatusCodes.Status404NotFound => "O recurso solicitado não foi encontrado.",
            StatusCodes.Status400BadRequest => "Existem erros de validação nos dados enviados.",
            _ => "Ocorreu um erro inesperado no servidor."
        };

        var response = new
        {
            StatusCode = statusCode,
            Mensagem = mensagem,
            Detalhes = exception is not null && exception.InnerException == null ? exception.Message : "Erro desconhecido"
        };

        return context.Response.WriteAsJsonAsync(response);
    }
}
