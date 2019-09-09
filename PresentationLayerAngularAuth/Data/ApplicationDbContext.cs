using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using BusinessLogicLayer.Domains;

namespace PresentationLayerAngularAuth.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<AppUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public ApplicationDbContext(DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
            //base.Database.EnsureDeleted();// Удаляет базу если она есть
            //base.Database.EnsureCreated(); // Создает базу если ее нет
            //base.Database.Migrate(); //Выполняет последнюю миграцию
        }
    }
}
