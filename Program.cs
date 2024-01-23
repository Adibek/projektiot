using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Database;
using Microsoft.EntityFrameworkCore;
using TaskManager.Services;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services => {
        services.AddDbContext<TaskDb>(options =>
        {
            var connectionString = "Server=tcp:plserwer2.database.windows.net,1433;Initial Catalog=projektdb;Persist Security Info=False;User ID=aburdelski;Password=Adibek1111;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            options.UseSqlServer(connectionString);
        });
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddSingleton<DatabaseTaskService>();
    })
    .Build();

host.Run();
