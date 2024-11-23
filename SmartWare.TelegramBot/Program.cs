using SmartWare.TelegramBot.Models;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapPost("/send", async (Message message) =>
{
    try
    {
        var token = builder.Configuration.GetConnectionString("TelegramBotToken")
                    ?? throw new Exception("Telegram bot token is not configured!");

        var adminId = builder.Configuration.GetConnectionString("AdminId")
                      ?? throw new Exception("Admin id is not configured!");

        var client = new TelegramBotClient(token);

        await client.SendMessage(adminId,
            $"Ism: {message.FirstName} {message.LastName}\n " +
            $"Contact: {message.Email}, {message.Number}\n " +
            $"Xabar: {message.Content}");

        return Results.Ok();
    }
    catch (Exception exception)
    {
        return Results.BadRequest(exception.Message);
    }
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();