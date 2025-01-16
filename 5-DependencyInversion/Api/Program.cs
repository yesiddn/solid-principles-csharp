using DependencyInversion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// inyección de dependencias se puede hacer de tres formas
// 1. Singleton: se crea una sola instancia de la clase y se reutiliza en toda la aplicación
// 2. Scoped: se crea una instancia por cada petición
// 3. Transient: se crea una instancia por cada petición o uso, es decir, si se usa en un constructor y una propiedad, se crean dos instancias en el mismo objeto
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ILogbook, Logbook>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(options =>
  {
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
  });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
