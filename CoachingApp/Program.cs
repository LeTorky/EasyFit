// Importing dependancies
using Microsoft.AspNetCore.Identity;
using CoachingApp.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using CoachingApp.Interfaces;
using CoachingApp.Implementations;
// Create application builder.
var builder = WebApplication.CreateBuilder(args); // Creates builder.

builder.Services.AddCors(options => // Cross Origin Policy.
{
    options.AddPolicy(name: "Default", policy =>
    {
        policy.WithOrigins("https://coachingg.herokuapp.com").WithMethods().AllowAnyHeader().AllowCredentials();
    });
});
// Add services to the container.
builder.Services.AddControllers() // Maps URL with controllers.
    .AddNewtonsoftJson(options => // Serializes Action returns.
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; // Handles Loop Referencing.
    }); 
builder.Services.AddDbContext<IdentityApplicationContext>(optionsAction => // DBContext DI.
    {
        optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConneciton")); // Fetches connection string.
    });
builder.Services.AddIdentity<IdentityApplicationUser, IdentityApplicationRoles>(setupAction => // Identity DI.
{
    SignInOptions SignInOpt = new SignInOptions();
    SignInOpt.RequireConfirmedPhoneNumber = false;
    SignInOpt.RequireConfirmedEmail = false;
    SignInOpt.RequireConfirmedAccount = false;
    setupAction.SignIn = SignInOpt;
}).AddEntityFrameworkStores<IdentityApplicationContext>() // Adds custom Identity DBContext.
.AddUserManager<IdentityUserManager>() // Adds custom User Manager.
.AddDefaultTokenProviders(); // Adds default Token Provider.
builder.Services.AddAuthorization(); // Adds Authorization.
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = false;
    options.Cookie.Name = "EasyFit";
    options.Cookie.SecurePolicy = CookieSecurePolicy.None;
    options.ExpireTimeSpan = DateTime.Now.Subtract(DateTime.UtcNow).Add(TimeSpan.FromDays(5));
});
// Injecting dependancies.
builder.Services.AddTransient<ITest, Test>();
builder.Services.AddTransient<ICoachManager, CoachManager>();
builder.Services.AddTransient<IClientManager, ClientManager>();
builder.Services.AddTransient<IExerciseManager, ExerciseManager>();
builder.Services.AddTransient<IWorkoutManager, WorkoutManager>();
builder.Services.AddTransient<IWorkoutSetsManager, WorkoutSetsManager>();
builder.Services.AddTransient<IMealManager, MealManager>();
builder.Services.AddTransient<IWSubscriptionManager, WSubscriptionManager>();
builder.Services.AddTransient<INSubscriptionManager, NSubscriptionManager>();

// Swagger API documentation.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors("Default");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
