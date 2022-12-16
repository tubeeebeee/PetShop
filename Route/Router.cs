using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;

namespace PetShop.Route
{
    public static class Router
    {
        public static IApplicationBuilder UseMyRoutes(this IApplicationBuilder app)
        {
            app.UseRewriter(new RewriteOptions()
              .AddRewrite(@"dang-nhap.html", "Customer/Login", skipRemainingRules: true)
              );

            return app;
        }
    }
}
