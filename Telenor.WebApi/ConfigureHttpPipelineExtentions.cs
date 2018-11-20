using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Telenor.Infrastructure;

namespace Telenor.WebApi
{
    public static class ConfigureHttpPipelineExtentions
    {
        public static int EnsureDatabaseIsSeeded(this IApplicationBuilder applicationBuilder)
        {
            // seed the database using an extension method
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CatalogContext>();
                return context.EnsureSeedData();
            }
        }
    }
}
