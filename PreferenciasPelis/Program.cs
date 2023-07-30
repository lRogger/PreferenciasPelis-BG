using System.Reflection;
using OpenApiInfo = Microsoft.OpenApi.Models.OpenApiInfo;
using NSwag.Generation.Processors.Security;
using PreferenciaPeli.Servicios;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();


builder.Services.AddControllers().AddJsonOptions(c =>
{
    c.JsonSerializerOptions.PropertyNamingPolicy = null;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocument();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Peliculas Preferidas",
            Description = "APIs para consumir peliculas preferidas",
            Version = "v1"
        });

    // Set the comments path for the Swagger JSON and UI.**
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});



builder.Services.AddUserServices();
builder.Services.AddPeliculaServices();

//AuthCodeAAD
builder.Services.AddOpenApiDocument(document =>
{
    document.Title = "Peliculas-API";
    document.Version = "v1-Peliculas-API";
    document.DocumentName = "v1-Peliculas-API";

    //document.ApiGroupNames = OAuthFlow.ClientCredentialsAAD.GetGroupNames();
    document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("bearer"));
});

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi3();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
