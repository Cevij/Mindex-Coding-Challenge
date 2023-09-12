using CodeChallenge.Data.Contexts;
using CodeChallenge.Models.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace CodeChallenge.Config
{
    public static class WebApplicationBuilderExt
    {
        /// <summary>
        /// Create DB instance for <see cref="EmployeeContext"/>.
        /// </summary>
        /// <param name="builder">A builder for web app and builders.</param>
        public static void UseEmployeeDB(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<EmployeeContext>(options =>
            {
                options.UseInMemoryDatabase(CONFIG_CONSTANTS.DB_NAME);
            });
        }

        /// <summary>
        /// Create DB instance for <see cref="CompensationEmployeeContext"/>.
        /// </summary>
        /// <param name="builder">A builder for web app and builders.</param>
        public static void UseCompensationEmployeeDB(this WebApplicationBuilder builder)
        {

            builder.Services.AddDbContext<CompensationEmployeeContext>(options => {
                options.UseInMemoryDatabase(CONFIG_CONSTANTS.COMPENSATION_DB_NAME);
            });
        }
    }
}
