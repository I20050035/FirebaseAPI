using FirebaseAdmin;
using FirebaseAPI;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inicializar Firebase con el archivo de credenciales correcto
FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile("biblioteca-d571c-firebase-adminsdk-kdq5l-2fd35d8f0f.json")
});

// Agregar el servicio de Firebase
builder.Services.AddSingleton<FirebaseService>();

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
