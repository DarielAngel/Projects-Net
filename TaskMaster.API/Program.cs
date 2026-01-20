using Microsoft.EntityFrameworkCore;
using TaskMaster.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. AGREGAR SERVICIOS DE CONTROLADORES (Indispensable)
builder.Services.AddControllers();

// 3. Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 5. MAPEAR CONTROLADORES (Aquí es donde se activa tu TasksController)
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();