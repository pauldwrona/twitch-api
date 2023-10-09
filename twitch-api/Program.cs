using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using twitch_api.Models;
using twitch_api.Controllers;



var builder = WebApplication.CreateBuilder(args);
/*
// Add services to the container.

builder.Services.AddDbContext<PollContext>(options =>
    options.UseInMemoryDatabase("Poll")); */

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

/*using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<PollContext>();

    context.Polls.Add(new Poll { OwnerId = -1, Name = "TestPoll", Description = "", Status = "" });
    await context.SaveChangesAsync();
}*/

app.Run();

