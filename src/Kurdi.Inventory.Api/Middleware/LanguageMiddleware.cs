
using Kurdi.Inventory.Api.Helpers;

namespace Kurdi.Inventory.Api.Middleware
{

    public class LanguageMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            List<string> supportedLanguages = ["ar", "en"];

            var validLanguage = true;
            string? languageHeader = context.Request.Headers["Language"];
            if (!string.IsNullOrEmpty(languageHeader))
            {
                if (!supportedLanguages.Contains(languageHeader))
                {
                    context.Response.StatusCode = 404;
                    validLanguage = false;
                    var responseBody = new
                    {
                        successed = false,
                        message = Translator.Translate("VALIDATION:NOT_VALID_LANGUAGE")
                    };
                    await context.Response.WriteAsJsonAsync(responseBody);
                }

                LanguageInfoHelper.CurrentLanguage = languageHeader;
            }
            else
            {
                LanguageInfoHelper.CurrentLanguage = "en";
            }

            if (validLanguage)
            {
                await next(context);
            }
        }
    }

    public static class LanguageMiddlewareExtensions
    {
        public static IApplicationBuilder UseLanguageMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LanguageMiddleware>();
        }
    }
}