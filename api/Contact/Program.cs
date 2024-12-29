using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

using Contact.Utility;
using Contact.Business;
using Contact.Data;

namespace Contact
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            string cs = builder.Configuration.GetSection("Connection").Value;

            builder.Services.AddTransient<SqlConnection>(x => new SqlConnection(cs));

            builder.Services.AddTransient<Crud>();

            builder.Services.AddTransient<UserBusiness>();
            builder.Services.AddTransient<ContactBusiness>();

            builder.Services.AddTransient<UserData>();
            builder.Services.AddTransient<ContactData>();

            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication().AddJwtBearer(x =>
            {
                x.TokenValidationParameters = Token.Params;
            });

            var app = builder.Build();

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseAuthorization();
            //app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
