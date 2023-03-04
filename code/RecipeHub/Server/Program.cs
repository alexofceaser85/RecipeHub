using Server.Data.Settings;
using Server.Service.PlannedMeals;
using Server.Service.Users;
using Shared_Resources.Utils.Dates;

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

var removeTimedOutSessionKeysThread = new Thread(() =>
{
    var usersService = new UsersService();
    while (true)
    {
        usersService.RemoveTimedOutSessionKeys();
        Thread.Sleep(ServerSettings.RemovedTimeOutSessionKeysThreadInterval);
    }
});

var removeOldPlannedMealsThread = new Thread(() =>
{
    var plannedMealsService = new PlannedMealsService();
    while (true)
    {
        plannedMealsService.RemoveOutOfDateMeals(DateUtils.GenerateDateTimeForEndOfPreviousWeek(DateTime.UtcNow));
        Thread.Sleep(ServerSettings.RemovedPlannedMealsThreadInterval);
    }
});

removeTimedOutSessionKeysThread.Start();
removeOldPlannedMealsThread.Start();

app.Run();
