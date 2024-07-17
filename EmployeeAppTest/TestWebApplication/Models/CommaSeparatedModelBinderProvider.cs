using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TestWebApplication.Models
{
    public class CommaSeparatedModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            //ModelType: Gets the model type represented by the current instance
            if (context.Metadata.ModelType == typeof(List<int>))
            {
                return new CommaSeparatedModelBinder();
            }
            if(context.Metadata.ModelType == typeof(ComplexUser))
            {
                return new ComplexUserModelBinder();
            }
            return null;
        }
    }
}
