namespace QuartzProject.Services;

public interface IDatabaseBackupService
{
    Task BackupDatabaseAsync();
}
