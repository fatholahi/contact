using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Contact.Utility;

namespace Contact
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            //builder.Services.AddAuthorization();
            //builder.Services.AddAuthentication().AddJwtBearer(x =>
            //{
            //    x.TokenValidationParameters = Token.Params;
            //});

            var app = builder.Build();

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            //app.UseAuthorization();
            //app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
