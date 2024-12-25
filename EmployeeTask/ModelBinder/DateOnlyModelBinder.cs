using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Globalization;
using System.Threading.Tasks;

public class DateOnlyModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        var value = valueProviderResult.FirstValue;

        if (DateOnly.TryParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateOnly))
        {
            bindingContext.Result = ModelBindingResult.Success(dateOnly);
        }
        else
        {
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Invalid date format.");
        }

        return Task.CompletedTask;
    }
}
