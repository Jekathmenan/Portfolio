﻿using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Simulate sending email
        Console.WriteLine($"Sending email to {email} with subject '{subject}'");
        return Task.CompletedTask;
    }
}
