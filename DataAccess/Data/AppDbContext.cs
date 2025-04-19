using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        // Add new migration
        // dotnet ef migrations add Name --project "DataAccess" --startup-project "Presenter-Layer" 

        // remove migration
        // dotnet ef migrations remove Name --project "DataAccess" --startup-project "Presenter-Layer" 

        // database update
        // dotnet ef database update --project "DataAccess" --startup-project "Presenter-Layer" 

        // ----------------------------Entites------------------------------ 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }

    }

}
