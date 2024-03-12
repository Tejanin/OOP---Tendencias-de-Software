using Microsoft.EntityFrameworkCore;
using oopDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FoodContext>(x => 
x.UseSqlServer(builder.Configuration.GetConnectionString("oopDB"))
);

builder.Services.AddScoped<IRepository<Product>,Repository<Product> >();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<FoodContext>();
    context.Database.Migrate();
}
    app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
