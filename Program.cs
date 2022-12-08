using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using WebAPI;
using WebAPI.Contexts;
using WebAPI.Middlewares;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new ApiVersion(1, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                    new HeaderApiVersionReader("x-api-version"),
                                                    new MediaTypeApiVersionReader("x-api-version"));
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

// Creando el servicio para la creacion de base de datos
//builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("DefaultConexionString"));
builder.Services.AddSqlite<TareasContext>(builder.Configuration.GetConnectionString("ConexionStringLite"));

//Configurando serializacion, para eliminar consultas ciclicas
builder.Services.AddMvc().AddNewtonsoftJson(
    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

//Creacion de inyeccion de dependencias
//builder.Services.AddScoped<IHelloWorldService>( d => new HelloWorldService());  //Inyeccion de dependencia por clase
builder.Services.AddScoped<ICategoriasService, CategoriasService>();
builder.Services.AddScoped<ITareasService, TareasService>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline. Pipeline es la secuencia de ejecucion de middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

#region AsegurandoConexionDB
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        
        try
        {
            var context = services.GetRequiredService<TareasContext>();
            context.Database.EnsureCreated();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Error en la creacion de la base de datos.");
        }
    }
#endregion

//Despues del Middleware de authorization se ubican los Custom Middlewares
//Agregando el Middleware WelcomePage
//app.UseWelcomePage();

//Creacion y ejecucion de nuevo middleware
//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
