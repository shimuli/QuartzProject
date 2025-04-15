using Quartz;
using QuartzProject.Services;

namespace QuartzProject.Jobs;


[DisallowConcurrentExecution] // Prevent concurrent execution of this job
public class DatabaseBackupJob(IDatabaseBackupService _backupService) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        await _backupService.BackupDatabaseAsync();
    }
}
