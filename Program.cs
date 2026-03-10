var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddSingleton<ICitaBd,CitaBd>();
builder.Services.AddSingleton<IMedicoBd,MedicoBd>();
builder.Services.AddSingleton<IPacienteBd,PacienteBd>();

builder.Services.AddSingleton<ICitaService, CitaService>();
builder.Services.AddSingleton<IMedicoService, MedicoService>();
builder.Services.AddSingleton<IPacienteService, PacienteService>();



builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
