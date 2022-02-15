using BookStore.API.Services;
using BookStore.API.Services.Contracts;
using BookStore.API.Settings;
using BookStore.API.Settings.Contracts;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.


builder.Services.Configure<BookStoreDatabaseSettings>(
    configuration.GetSection(nameof(BookStoreDatabaseSettings)));

builder.Services.AddSingleton<IBookStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<BookStoreDatabaseSettings>>().Value);

builder.Services.AddScoped<IBooksService, BooksService>();

builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("BookStoreDatabase"));

builder.Services.AddSingleton<BooksService>();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
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

app.UseAuthorization();

app.MapControllers();

app.Run();
