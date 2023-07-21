using Infraestructure.Repository.Interface;
using Infraestructure.Repository;
using Infraestructure.UnitOfWork.Interface;
using Infraestructure.UnitOfWork;
using Library.Domain.Services.Interfaces;
using Library.Domain.Services;

namespace LibraryWeb.Handlers
{
    public static class DependencyInyectionHandler
    {
        public static void DependencyInyectionConfig(IServiceCollection services)
        {

            // Infrastructure
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped<SeedDb>();

            ////Domain
            services.AddTransient<IAuthorServices, AuthorServices>();
            services.AddTransient<IEditorialServices, EditorialServices>();
            services.AddTransient<IBookServices, BookServices>();
            services.AddTransient<IRoleServices, RoleServices>();
            services.AddTransient<IUserServices, UserServices>();

        }
    }
}
