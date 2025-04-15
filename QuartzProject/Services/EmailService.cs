using QuartzProject.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace QuartzProject.Services;

public class EmailService : IEmailService
{
    public async Task SendStatementAsync(Customer customer)
    {
        try
        {
            var timenow = DateTime.Now;
            Console.WriteLine($"Sending Email to {customer.Email}: {customer.Statement}, at {timenow}");
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
   
    }
}
