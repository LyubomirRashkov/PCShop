using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PCShop.ModelBinders
{
	/// <summary>
	/// Custom decimal model binder provider
	/// </summary>
	public class DoubleModelBinderProvider : IModelBinderProvider
	{
		/// <summary>
		/// Creates a DoubleModelBinder based on ModelBinderProviderContext
		/// </summary>
		/// <param name="context">The ModelBinderProviderContext</param>
		/// <returns>A DoubleModelBinder</returns>
		/// <exception cref="ArgumentNullException">Thrown when ModelBinderProviderContext is null</exception>
		public IModelBinder? GetBinder(ModelBinderProviderContext context)
		{
			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			if (context.Metadata.ModelType == typeof(Double) || context.Metadata.ModelType == typeof(Double?))
			{
				return new DoubleModelBinder();
			}

			return null;
		}
	}
}
