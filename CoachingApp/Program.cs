// Importing dependancies
using Microsoft.AspNetCore.Identity;
using CoachingApp.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using CoachingApp.Interfaces;
using CoachingApp.Implementations;

// Create application builder.
var builder = WebApplication.CreateBuilder(args); // Creates builder.

// Add services to the container.
builder.Services.AddControllers(); // Maps URL with controllers.
builder.Services.AddDbContext<IdentityApplicationContext>(optionsAction => // DBContext DI.
{
    optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConneciton")); // Fetches connection string.
});
builder.Services.AddIdentity<IdentityApplicationUser, IdentityRole>(setupAction => // Identity DI.
{
    SignInOptions SignInOpt = new SignInOptions();
    SignInOpt.RequireConfirmedPhoneNumber = false;
    SignInOpt.RequireConfirmedEmail = false;
    SignInOpt.RequireConfirmedAccount = false;
    setupAction.SignIn = SignInOpt;
}).AddEntityFrameworkStores<IdentityApplicationContext>(); // Adds custom Identity DBContext.

// Injecting dependancies.
builder.Services.AddTransient<ITest, Test>();

// Swagger API documentation.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
