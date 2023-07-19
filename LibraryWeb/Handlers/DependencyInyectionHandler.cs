using Infraestructure.Repository.Interface;
using Infraestructure.Repository;
using Infraestructure.UnitOfWork.Interface;
using Infraestructure.UnitOfWork;

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
            

            //services.AddTransient<IUserServices, UserServices>();

            //services.AddTransient<IRoleServices, RoleServices>();

            

        }
    }
}
