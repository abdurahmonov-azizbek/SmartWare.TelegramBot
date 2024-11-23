namespace SmartWare.TelegramBot.Models;

public class Message
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Number { get; set; }
    public string? Email { get; set; }
    public string Content { get; set; } = string.Empty;
}