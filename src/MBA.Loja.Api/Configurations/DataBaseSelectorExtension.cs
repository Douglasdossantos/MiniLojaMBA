using MBA.Loja.Api.Data;
using MBA.Loja.Data.Context;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace MBA.Loja.Api.Configurations
{
    public static  class DataBaseSelectorExtension
    {
        public static void  AddDatabaseSelector(this WebApplicationBuilder builder) 
        {
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<MyDbContext>(options =>
                {
                    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnectionLite"));
                });
                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnectionLite"));
                });

                builder.Services.AddIdentityConfig(builder.Configuration);
            }
            else
            {
                builder.Services.AddDbContext<MyDbContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                });
                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                });

                builder.Services.AddIdentityConfig(builder.Configuration);
            }
        }   
    }
}
