using Policy.Models;
using Microsoft.EntityFrameworkCore;
using Policy.Repository;
using Microsoft.OpenApi.Models;

namespace Policy
{ 
    public class Program
    { 
        public static void Main(string[] args)
        { 
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.          

            var connectionString = builder.Configuration.GetConnectionString("SalesInsurance");
            builder.Services.AddDbContext<ApiContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Policy", Version = "v1" });
                c.DocumentFilter<SwaggerDocumentFilter>();
            });

            builder.Services.AddMvc();

            builder.Services.AddScoped<IPolicyRepository, PolicyRepository>();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddTransient<IPolicyRepository, PolicyRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

           app.MapControllers();

            app.Run();
        }

    }

}