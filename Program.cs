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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.RegisterMiddlewares();

app.Run();
