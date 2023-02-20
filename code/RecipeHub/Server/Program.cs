using Server.Data.Settings;
using Server.Service.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

var thread = new Thread(() =>
{
    var usersService = new UsersService();
    while (true)
    {
        usersService.RemoveTimedOutSessionKeys();
        Thread.Sleep(ServerSettings.RemovedTimeOutSessionKeysThreadInterval);
    }
});

thread.Start();

app.Run();
