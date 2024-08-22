using DRAKaysaResende.Data;
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
builder.Services.AddDbContext<DataContext>();


var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();


app.Run();
