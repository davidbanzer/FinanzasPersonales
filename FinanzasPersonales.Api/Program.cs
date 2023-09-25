
using FinanzasPersonales.Api;
using FinanzasPersonales.Application;
using FinanzasPersonales.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastucture(builder.Configuration);
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
