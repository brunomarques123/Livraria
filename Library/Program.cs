using Library.Application;
using Library.Core.Repositories;
using Library.ExceptionHandler;
using Library.Infrastructure.Persistence;
using Library.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library
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


            builder.Services.AddExceptionHandler<ApiExceptionHandler>();

            var connectionString = builder.Configuration.GetConnectionString("LibraryCs");
            builder.Services.AddDbContext<LibraryDbContext>(o => o.UseSqlServer(connectionString));

            builder.Services.AddApplication();

            // Register Repositories
            builder.Services.AddTransient<IBookRepository, BookRepository>();
            builder.Services.AddTransient<ILoanRepository, LoanRepository>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();

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
