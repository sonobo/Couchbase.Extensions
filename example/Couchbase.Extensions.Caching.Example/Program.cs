using Couchbase.Extensions.Caching;
using Couchbase.Extensions.DependencyInjection;

namespace Couchbase.Extensions.Caching.Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCouchbase(opt =>
            {
                opt.ConnectionString = "couchbase://localhost";
                opt.UserName = "Administrator";
                opt.Password = "password";
            });

            builder.Services.AddDistributedCouchbaseCache("default", opt => { });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}