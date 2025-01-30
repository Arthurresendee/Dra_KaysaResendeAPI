using drakaysa.Data;
using drakaysa.Models;
using drakaysa.Services.Validators;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    policy => {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

});

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    })
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddScoped<EnderecoValidator>();
builder.Services.AddScoped<DentistaValidator>();
builder.Services.AddScoped<CardValidator>();
builder.Services.AddScoped<TopicoValidator>();
builder.Services.AddScoped<PacienteValidator>();

builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<DataContext>();

        if (!context.Database.CanConnect())
        {
            context.Database.Migrate();
            SeedData(context);
            Console.WriteLine("Banco de dados migrado e dados iniciais inseridos.");
        }
        else
        {
            Console.WriteLine("Banco de dados já existe. Migração ignorada.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao verificar/aplicar as migrations: {ex.Message}");
    }
}


app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();

app.Run();

// Método para inserir os dados iniciais no banco
void SeedData(DataContext context)
{
    if (!context.Topicos.Any()) // Verifica se já existem registros
    {
        var topicos = new List<Topico>
        {
            new Topico
            {
                TituloTopico = "Benefícios",
                Cards = new List<Card>
                {
                    new Card { Titulo = "Melhora Estética", Texto = "Transforma a aparência dos dentes, corrigindo imperfeições como manchas, descolorações, desgastes, espaçamentos e desalinhamentos leves." },
                    new Card { Titulo = "Procedimento menos invasivo", Texto = "Diferente das facetas de porcelana, as facetas em resina podem ser aplicadas com mínimo ou nenhum desgaste da estrutura dental natural." },
                    new Card { Titulo = "Estética natural", Texto = "As facetas em resina proporcionam uma aparência altamente natural, reproduzindo com precisão a translucidez, o brilho e a cor dos dentes, garantindo um sorriso harmonioso e autêntico." }
                }
            },
            new Topico
            {
                TituloTopico = "Perguntas Frequentes",
                Cards = new List<Card>
                {
                    new Card { Titulo = "Quanto tempo dura o tratamento?", Texto = "Para facetas de resina, o procedimento dura cerca de 5 horas, pois cada dente é esculpido à mão com muita precisão e delicadeza." },
                    new Card { Titulo = "As facetas são resistentes?", Texto = "Sim, porém, é importante evitar hábitos como roer unhas, morder objetos duros e ranger os dentes, pois esses comportamentos podem comprometer a durabilidade." },
                    new Card { Titulo = "Qual é o custo do procedimento?", Texto = "O custo varia do número de dentes e da complexidade do caso. A melhor forma de determinar o valor é agendar uma consulta para avaliar as suas necessidades." }
                }
            }
        };

        context.Topicos.AddRange(topicos);
        context.SaveChanges();
        Console.WriteLine("Dados iniciais inseridos com sucesso!");
    }
}



