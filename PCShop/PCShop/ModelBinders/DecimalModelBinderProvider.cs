using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PCShop.ModelBinders
{
	/// <summary>
	/// Custom decimal model binder provider
	/// </summary>
	public class DecimalModelBinderProvider : IModelBinderProvider
	{
		/// <summary>
		/// Creates a DecimalModelBinder based on ModelBinderProviderContext
		/// </summary>
		/// <param name="context">The ModelBinderProviderContext</param>
		/// <returns>A DecimalModelBinder</returns>
		/// <exception cref="ArgumentNullException">Thrown when ModelBinderProviderContext is null</exception>
		public IModelBinder? GetBinder(ModelBinderProviderContext context)
		{
			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			if (context.Metadata.ModelType == typeof(Decimal) || context.Metadata.ModelType == typeof(Decimal?))
			{
				return new DecimalModelBinder();
			}

			return null;
		}
	}
}
