using Quartz;
using QuartzProject.Models;
using QuartzProject.Services;

namespace QuartzProject.Jobs;

[DisallowConcurrentExecution] // Prevent concurrent execution of this job
public class SendStatementJob(IEmailService _emailService) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        // Normally you'd get this from DB
        var customers = new List<Customer>
        {
            new Customer { Name = "Alice", Email = "alice@example.com", Statement = "Statement for Alice..." },
            new Customer { Name = "Bob", Email = "bob@example.com", Statement = "Statement for Bob..." }
        };

        foreach (var customer in customers)
        {
            await _emailService.SendStatementAsync(customer);
        }
    }
}
