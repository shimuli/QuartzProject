namespace QuartzProject.Services;

public class SmsService : ISmsService
{
    public async Task SendSmsAsync(string phoneNumber, string message)
    {
        // Integrate with Twilio or other provider here
        Console.WriteLine($"Sending SMS to {phoneNumber}: {message}");
        await Task.CompletedTask;
    }
}
