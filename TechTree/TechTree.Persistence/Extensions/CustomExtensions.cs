using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTree.Domain.Entities;
using TechTree.Persistence.Contexts;

namespace TechTree.Persistence.Extensions
{
    public static class CustomExtensions
    {
        public static void AddCustomServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(connectionString));

            services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount=false).AddEntityFrameworkStores<ApplicationDbContext>();


        }
    }
}
