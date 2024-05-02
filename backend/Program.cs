using backend.Context;
using backend.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BrasContext>();
builder.Services.AddScoped<IBrasContext, BrasContext>();
builder.Services.AddScoped<IChampionshipRepository, ChampionshipRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ITeamChampionshipLinkRepository, TeamChampionshipLinkRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // app.UseCors(builder => builder.WithOrigins("https://localhost:7059") // Substitua por seu domínio
    //                               .WithMethods("GET", "POST", "PT", "DELETE")
    //                               .WithHeaders("Authorization", "Content-Type")
    //                               .AllowCredentials()
    //                               .SetIsOriginAllowedToAllowWildcardSubdomains()
    //                               .WithExposedHeaders("WWW-Authenticate"));
}

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();