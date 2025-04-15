using QuartzProject.Models;

namespace QuartzProject.Services;

public interface IEmailService
{
    Task SendStatementAsync(Customer customer);
}
