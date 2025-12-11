namespace FoodHub.API.Configurations
{
	public static class SwaggerAppConfig
	{
		public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "FoodHub API v1");
				c.RoutePrefix = string.Empty;
			});

			return app;
		}
	}
}
