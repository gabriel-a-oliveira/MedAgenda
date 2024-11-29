namespace MedAgenda.ExceptionMiddleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

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
            ArgumentException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        var mensagem = statusCode switch
        {
            StatusCodes.Status404NotFound => "O recurso solicitado não foi encontrado.",
            StatusCodes.Status400BadRequest => "A requisição está mal formulada. Verifique os dados enviados.",
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
