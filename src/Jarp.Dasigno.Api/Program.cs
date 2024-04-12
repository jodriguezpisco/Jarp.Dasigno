using Jarp.Dasigno.Api;
using Jarp.Dasigno.Application;
using Jarp.Dasigno.Common;
using Jarp.Dasigno.External;
using Jarp.Dasigno.Persistence;
using Jarp.Dasigno.Persistence.DataBase;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
    options.RoutePrefix = string.Empty;
});


// Valida si existe la BD, si no la crea con sus objetos
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<DataBaseService>();
    dbContext.Database.EnsureCreated();
}

app.MapControllers();
app.Run();

