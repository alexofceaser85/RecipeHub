using System.Diagnostics;
using Server.DAL.Users;

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

var x = UsersDal.Login("adecesare",
    "2be5af1fdaf9f63b470918613531bf4b515a5fd17656cd558b0a2306fd6bfa1047e778e83fd90ac8b7a06599a42a8780ab02ed0ea9abcf1a6d9398084481bc01");
var y = UsersDal.Login("jcorley",
    "3be5af1fdaf9f63b470918613531bf4b515a5fd17656cd558b0a2306fd6bfa1047e778e83fd90ac8b7a06599a42a8780ab02ed0ea9abcf1a6d9398084481bc01");
Debug.WriteLine(x);
Debug.WriteLine(y);

app.Run();
