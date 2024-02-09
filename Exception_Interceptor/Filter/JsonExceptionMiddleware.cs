using Newtonsoft.Json;

namespace Exception_Interceptor.Filter
{
    public class JsonExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public JsonExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var result = JsonConvert.SerializeObject(ex);
                await httpContext.Response.WriteAsync(result);
            }
        }
    }
}
