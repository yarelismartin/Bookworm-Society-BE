using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);


// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
//builder.Services.AddNpgsql<Bookworm-SocietyDbContext>(builder.Configuration["Bookworm-SocietyDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

//builder.Services.AddScoped<IBookService, BookService>();
//builder.Services.AddScoped<IBookRepository, BookRepository>();

//builder.Services.AddScoped<IAuthorService, AuthorService>();
//builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.Run();