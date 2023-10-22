using API.Middleware;

namespace API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddApplicationBuilder(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            //Gönderilen adres bizde bulunmuyorsa ErrorController'a yönlendirme
            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            return app;
        }
    }
}
