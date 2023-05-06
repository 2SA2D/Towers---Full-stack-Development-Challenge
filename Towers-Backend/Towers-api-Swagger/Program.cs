using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Towers_api.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // enable CORS to allow angular project to use the api
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                              policy =>
                              {
                                  policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                              });
        });
        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors(MyAllowSpecificOrigins);

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
        


    }
}