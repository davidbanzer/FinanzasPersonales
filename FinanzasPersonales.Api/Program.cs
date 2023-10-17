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

// Add CORS policy to allow requests from localhost
app.UseCors(policy => policy.WithOrigins("http://localhost:8100").AllowAnyMethod().AllowAnyHeader());

{
    //app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}