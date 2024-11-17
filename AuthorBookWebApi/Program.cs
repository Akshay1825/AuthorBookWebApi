
using AuthorBookWebApi.Data;
using AuthorBookWebApi.Exceptions;
using AuthorBookWebApi.Mappers;
using AuthorBookWebApi.Repositories;
using AuthorBookWebApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace AuthorBookWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("connString"));
            });
            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddTransient<IAuthorService,AuthorService>();
            builder.Services.AddTransient<IBookService, BookService > ();
            builder.Services.AddTransient<IAuthorDetailsService, AuthorDetailsService>();
            builder.Services.AddControllers();

            //Ignore Cyclic Issues
            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddExceptionHandler<ExceptionHandler>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseExceptionHandler(_ => { });
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
