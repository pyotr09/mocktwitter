using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using mocktwitter_backend.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MockTwitterContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("mocktwitter_backendContext") ?? throw new InvalidOperationException("Connection string 'MockTwitterContext' not found.")));


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "All",
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader();
                      });
});

builder.Services.AddControllers();

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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
