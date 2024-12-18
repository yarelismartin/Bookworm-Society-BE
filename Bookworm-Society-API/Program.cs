using Bookworm_Society_API.Interfaces;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;
using Bookworm_Society_API.Services;
using Bookworm_Society_API.Repositories;
using Bookworm_Society_API.Endpoints;
using Bookworm_Society_API.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders(); // Optional: Remove other providers if needed
builder.Logging.AddConsole(); // Log to the console

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<Bookworm_SocietyDbContext>(builder.Configuration["Bookworm-SocietyDbConnectionString"]);

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
        policy.WithOrigins("http://localhost:3000", "http://localhost:5003")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapBookClubEndpoints();
app.MapBookEndpoints(); 
app.MapCommentEndpoints();
app.MapPostEndpoints();
app.MapReviewEndpoints();
app.MapUserEndpoints();
app.MapVoteEndpoints();
app.MapVotingSessionEndpoints();

app.Run();