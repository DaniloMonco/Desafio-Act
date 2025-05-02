using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FluxoCaixa.Migrations
{
    public static class MigrationManager
    {
        public static IHost Migrate(this IHost app, ServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var runner = scope.ServiceProvider.GetService<IMigrationRunner>();
                runner.ListMigrations();
                runner.MigrateUp(20250427000001);
            }
            return app;
        }
    }
}
