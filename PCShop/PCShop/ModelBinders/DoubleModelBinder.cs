using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace PCShop.ModelBinders
{
	/// <summary>
	/// Custom double model binder
	/// </summary>
	public class DoubleModelBinder : IModelBinder
	{
		/// <summary>
		/// Method that attempts to bind a model
		/// </summary>
		/// <param name="bindingContext">The Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext</param>
		/// <returns>A System.Threading.Tasks.Task which will complete when the model binding process completes. If model binding was successful, Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.Result will be set to a value returned from Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Success(System.Object).</returns>
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

			if (valueResult != ValueProviderResult.None && !String.IsNullOrEmpty(valueResult.FirstValue))
			{
				double actualValue = 0.0;

				bool success = false;

				try
				{
					string valueAsString = valueResult.FirstValue;

					valueAsString = valueAsString.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

					valueAsString = valueAsString.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

					actualValue = Convert.ToDouble(valueAsString, CultureInfo.CurrentCulture);

					success = true;
				}
				catch (FormatException fe)
				{
					bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
				}

				if (success)
				{
					bindingContext.Result = ModelBindingResult.Success(actualValue);
				}
			}

			return Task.CompletedTask;
		}
	}
}
