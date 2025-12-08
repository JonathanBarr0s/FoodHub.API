using Microsoft.OpenApi;

namespace FoodHub.API.Configurations.OpenApi
{
	public static class SwaggerConfig
	{
		public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "FoodHub API",
					Version = "v1",
					Description = string.Join("\n", new[]
					{
						"---",
						"### Contatos",
						"- **GitHub:** [github.com/jonathanbarr0s](https://github.com/jonathanbarr0s)",
						"- **Docker Hub:** [hub.docker.com/u/jonathanbarr0s](https://hub.docker.com/u/jonathanbarr0s)",
						"- **LinkedIn:** [linkedin.com/in/jonathansbarros](https://www.linkedin.com/in/jonathansbarros/)",
						"---",
						"Acesse meu [repositório](https://github.com/JonathanBarr0s/FoodHub.API) do GitHub para mais informações sobre esta API."
					})
				});
			});

			return services;
		}
	}
}
