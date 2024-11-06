using ApplicationCore;
using Infraestructure;
    
var builder = WebApplication.CreateBuilder(args);
// Aquí agregas los servicios de routing, controladores y otras configuraciones
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddApplicationCore();
// Aquí llamamos al método que configuramos previamente para la infraestructura
builder.Services.AddInfraestructure(builder.Configuration);

var app = builder.Build();

// Inicializamos la base de datos si es necesario
await app.Services.InitializeDatabasesAsync();

// Usamos la infraestructura que hayamos configurado (middleware, etc.)
app.UseInfraestructure();

// Ejecutamos la aplicación
app.Run();
