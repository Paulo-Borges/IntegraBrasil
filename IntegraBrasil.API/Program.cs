using IntegraBrasil.API.Interfaces;
using IntegraBrasil.API.Mappings;
using IntegraBrasil.API.Rest;
using IntegraBrasil.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IEnderecoService, EnderecoService>();
builder.Services.AddSingleton<IBancoService, BancoService>();
builder.Services.AddSingleton<IBrasilApi, BrasilApiRest>();
//builder.Services.AddSingleton<ICambioService, CambioService>();
//builder.Services.AddSingleton<IFipeService, FipeService>();

builder.Services.AddAutoMapper(config => { 

},typeof(EnderecoMapping), typeof(BancoMapping));

//builder.Services.AddAutoMapper(typeof(EnderecoMapping));
//builder.Services.AddAutoMapper(typeof(BancoMapping));
//builder.Services.AddAutoMapper(typeof(CambioMapping));
//builder.Services.AddAutoMapper(typeof(FipeMapping));

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
