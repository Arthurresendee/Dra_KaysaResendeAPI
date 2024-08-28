using DRAKaysa.Services.Validators;
using DRAKaysaResende.Data;
using DRAKaysaResende.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://127.0.0.1:5500")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});
builder.Services.AddControllers();
builder.Services.AddScoped<EnderecoValidator>();
builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();


app.Run();
