using CodeChallenge.Data.Contexts;
using CodeChallenge.Models.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace CodeChallenge.Config
{
    public static class WebApplicationBuilderExt
    {
        public static void UseEmployeeDB(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<EmployeeContext>(options =>
            {
                options.UseInMemoryDatabase(CONFIG_CONSTANTS.DB_NAME);
            });

            builder.Services.AddDbContext<CompensationEmployeeContext>(opt => {
                opt.UseInMemoryDatabase(CONFIG_CONSTANTS.COMPENSATION_DB_NAME);
            });
        }
    }
}
