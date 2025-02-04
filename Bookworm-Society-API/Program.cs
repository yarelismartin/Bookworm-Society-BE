using Bookworm_Society_API.Interfaces;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;
using Bookworm_Society_API.Services;
using Bookworm_Society_API.Repositories;
using Bookworm_Society_API.Endpoints;
using Bookworm_Society_API.Data;
using Microsoft.EntityFrameworkCore;
using Bookworm_Society_API.Utility;


var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders(); // Optional: Remove other providers if needed
builder.Logging.AddConsole(); // Log to the console

builder.Services.AddHealthChecks();// Allow health checks

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Determine environment-specific connection string
string connectionString;
if (builder.Environment.IsDevelopment())
{
    // Use local database in development
    connectionString = builder.Configuration["Bookworm-SocietyDbConnectionString"];
}
else
{
    // Fetch from Railway environment variable
    connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
}

// Set the database context
builder.Services.AddDbContext<Bookworm_SocietyDbContext>(options => options.UseNpgsql(connectionString));


// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddScoped<IVotingSessionService, VotingSessionService>();
builder.Services.AddScoped<IVotingSessionRepository, VotingSessionRepository>();

builder.Services.AddScoped<IVoteService, VoteService>();
builder.Services.AddScoped<IVoteRepository, VoteRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<IBookClubService, BookClubService>();
builder.Services.AddScoped<IBookClubRepository, BookClubRepository>();

builder.Services.AddScoped<IBaseRepository, BaseRepository>();

builder.Services.AddHostedService<VotingSessionChecker>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://fe-bookworm-society-production.up.railway.app")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Use health checks
app.UseHealthChecks("/health");
app.UseCors();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Only use HTTPS redirection in development
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<Bookworm_SocietyDbContext>();

    // Apply any pending migrations to the database
    await context.Database.MigrateAsync();

    // Run additional data management tasks
    await DataHelper.ManageDataAsync(scope.ServiceProvider);
}

app.MapBookClubEndpoints();
app.MapBookEndpoints(); 
app.MapCommentEndpoints();
app.MapPostEndpoints();
app.MapReviewEndpoints();
app.MapUserEndpoints();
app.MapVoteEndpoints();
app.MapVotingSessionEndpoints();

app.Run();