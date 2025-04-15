using Quartz;
using QuartzProject.Services;

namespace QuartzProject.Jobs;

[DisallowConcurrentExecution] // Prevent concurrent execution of this job
public class SendSmsReminderJob(ISmsService _smsService) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var customers = new List<(string Name, string Phone)>
        {
            ("Alice", "+254700000001"),
            ("Bob", "+254700000002")
        };

        foreach (var (name, phone) in customers)
        {
            var timenow = DateTime.Now;
            await _smsService.SendSmsAsync(phone, $"Hi {name}, your statement is available at {timenow}");
        }
    }
}
