using drakaysa.Data;
using drakaysa.Services.Validators;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Configurando a política CORS
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

// Adicionando FluentValidation
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    })
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

// Registrando os validadores
builder.Services.AddScoped<EnderecoValidator>();
builder.Services.AddScoped<DentistaValidator>();
builder.Services.AddScoped<CardValidator>();
builder.Services.AddScoped<TopicoValidator>();
builder.Services.AddScoped<PacienteValidator>();

// Configuração do SQLite
builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Aplicando as migrações automaticamente ao iniciar o aplicativo
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<DataContext>();
        context.Database.Migrate();  // Aplica as migrações automaticamente
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao aplicar as migrations: {ex.Message}");
    }
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();

app.Run();
