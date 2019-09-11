using BusinessLogicLayer.AreaServices.UserService;
using BusinessLogicLayer.AreaServices.UserService.Impl;
using BusinessLogicLayer.AreaServices.UserService.UserFactory;
using BusinessLogicLayer.AreaServices.UserService.UserFactory.Impl;
using DataAccessLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PresentationLayerAngularAuth.Data;

namespace PresentationLayerAngularAuth
{
    public partial class Startup
    {
        private void AddExtensions(IServiceCollection services)
        {
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserAreaService, UserAreaService>();
            services.AddScoped<IUserFactory, UserFactory>();
        }
    }
}