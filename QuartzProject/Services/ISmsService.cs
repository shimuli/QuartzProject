﻿namespace QuartzProject.Services;

public interface ISmsService
{
    Task SendSmsAsync(string phoneNumber, string message);
}
