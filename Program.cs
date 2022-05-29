using WebAPI;
using WebAPI.Middlewares;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Creacion de inyeccion de dependencias
//builder.Services.AddScoped<IHelloWorldService>( d => new HelloWorldService());  //Inyeccion de dependencia por clase
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<ICategoriasService, CategoriasService>();
builder.Services.AddScoped<ITareasService, TareasService>();

var app = builder.Build();

// Configure the HTTP request pipeline. Pipeline es la secuencia de ejecucion de middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Despues del Middleware de authorization se ubican los Custom Middlewares
//Agregando el Middleware WelcomePage
//app.UseWelcomePage();

//Creacion y ejecucion de nuevo middleware
app.UseTimeMiddleware();

app.MapControllers();

app.Run();
