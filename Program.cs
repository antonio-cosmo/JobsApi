using JobsApi.Core.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.RegisterDatabase();
builder.Services.RegisterJobRepository();
builder.Services.RegisterJobServices();
builder.Services.RegisterJobMapper();
builder.Services.RegisterJobRequestValidator();
builder.Services.RegisterAssemblers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.RegisterSwagger();
builder.Services.RegisterCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.RegisterMiddlewares();

app.Run();
