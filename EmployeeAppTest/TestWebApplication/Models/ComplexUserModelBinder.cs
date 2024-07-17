using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TestWebApplication.Models
{
    public class ComplexUserModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var headers = bindingContext.HttpContext.Request.Headers;
            var routeData = bindingContext.HttpContext.Request.RouteValues;
            var query = bindingContext.HttpContext.Request.Query;
            var user = new ComplexUser
            {
                Username = headers["X-Username"].ToString(),
                Country = routeData["country"].ToString(),
                Age = int.TryParse(query["age"].ToString(), out var age) ? age : 0,
                ReferenceId = query["refId"].ToString()
            };
            bindingContext.Result = ModelBindingResult.Success(user);
            return Task.CompletedTask;
        }
    }
}
