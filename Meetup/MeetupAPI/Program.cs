using Meetup.BusinessLayer.Extensions;
using Meetup.DataAccessLayer.Extensions;
using MeetupAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddSwagger();

// Add BL with DAL
builder.Services.AddBusinessLayer(builder.Configuration,
    builder.Configuration.GetConnectionString("MeetupConnection"));

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseCustomSwagger();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
