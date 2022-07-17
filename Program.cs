using WebAPI.Repositories;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddControllers();
builder.Services.AddScoped<ITurfirmaRepository>( s =>
    new TurfirmaRepository( builder.Configuration.GetValue<string>( "DefaultConnection" ) ) );
builder.Services.AddScoped<ITurfirmaService, TurfirmaService>();

var app = builder.Build();
app.MapControllers();
app.Run();