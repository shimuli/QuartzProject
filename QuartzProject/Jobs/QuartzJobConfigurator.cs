using Quartz;

namespace QuartzProject.Jobs;

public class QuartzJobConfigurator
{
    public static void ConfigureQuartzJobs(IServiceCollection services)
    {
        // Quartz Configuration
        services.AddQuartz(q =>
        {
            // Email Job - Send Statements
            JobKey emailJobKey = new JobKey("SendStatementsJob");
            q.AddJob<SendStatementJob>(opts => opts.WithIdentity(emailJobKey));

            q.AddTrigger(opts => opts
                .ForJob(emailJobKey)
                .WithIdentity("SendStatementsTrigger")
                .WithCronSchedule("0 0/2 10-15 ? * 3", x =>
                    x.InTimeZone(TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time")))); // Every 2 mins from 10AM–3:58PM on Tuesdays

            // SMS Job - Send SMS Reminders
            JobKey smsJobKey = new JobKey("SendSmsJob");
            q.AddJob<SendSmsReminderJob>(opts => opts.WithIdentity(smsJobKey));
            q.AddTrigger(opts => opts.ForJob(smsJobKey)
                .WithIdentity("SendSmsTrigger")
                .WithSimpleSchedule(x => x.WithIntervalInMinutes(2).RepeatForever())); // Every 2 minutes

            // Backup Job - Database Backup
            JobKey backupJobKey = new JobKey("DatabaseBackupJob");
            q.AddJob<DatabaseBackupJob>(opts => opts.WithIdentity(backupJobKey));
            q.AddTrigger(opts => opts.ForJob(backupJobKey)
                .WithIdentity("DatabaseBackupTrigger")
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(2, 0))); // Every day at 2 AM
        });

        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
    }
}
