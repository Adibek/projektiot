using Microsoft.Azure.Functions.Worker.Extensions.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TaskManager.Database
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<TaskDb>
    {
        public TaskDb CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaskDb>();
            optionsBuilder.UseSqlServer("Server=tcp:plserwer2.database.windows.net,1433;Initial Catalog=projektdb;Persist Security Info=False;User ID=aburdelski;Password=Adibek1111;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new TaskDb(optionsBuilder.Options);
        }
    }
}