using System.ComponentModel.DataAnnotations;
using System.Net;
using TmsMvc.Services;

namespace TmsMvcTask12.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                if (IsHomePath(context))
                {
                    var productService = context.RequestServices.GetRequiredService<IInventoryService>();
                    var products = productService.GetProducts();

                    if (products.Count == 0)
                    {
                        if (!context.Response.HasStarted)
                        {
                            context.Response.Redirect("/Home/AddProduct");
                            return;
                        }
                    }
                }

                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("Server error");
            }
        }

        private bool IsHomePath(HttpContext context)
        {
            return context.Request.Path == "/" || context.Request.Path == "/Home/ListProducts";
        }
    }
}
