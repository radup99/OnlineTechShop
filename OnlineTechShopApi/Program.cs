using OnlineTechShopApi.Database;
using OnlineTechShopApi.Repositories;
using OnlineTechShopApi.Services;

namespace OnlineTechShopApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<MainDbContext>();
            builder.Services.AddScoped<ProductRepository>();
            builder.Services.AddScoped<CategoryRepository>();
            builder.Services.AddScoped<FilterRepository>();
            builder.Services.AddScoped<UserRepository>();
			builder.Services.AddScoped<OrderRepository>();
			builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<FilterService>();
            builder.Services.AddScoped<UserService>();
			builder.Services.AddScoped<OrderService>();
			builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(builder => builder.AllowAnyOrigin());

            app.MapControllers();

            app.Run();
        }
    }
}
