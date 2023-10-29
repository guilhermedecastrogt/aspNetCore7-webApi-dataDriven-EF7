using Microsoft.EntityFrameworkCore;
using webApi_dataDriven.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

/*builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseInMemoryDatabase("Database"));*/
builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));
builder.Services.AddScoped<DataContext, DataContext>();

builder.Services.AddControllers();
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting();

app.Run();