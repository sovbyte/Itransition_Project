using Itransition_Project.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using MimeKit;

namespace Itransition_Project.Services;

public class SmtpEmailSender : IEmailSender<User>
{
    public async Task SendConfirmationLinkAsync(User user, string email, string confirmationLink)
    {
        const string subject = "Confirm Your Registration";
        var body = $"<h3>Welcome, {user.UserName}!</h3>" +
                   $"<p>Thank you for signing up. Please confirm your account by clicking <a href='{confirmationLink}'>this link</a>.</p>";

        await SendEmailAsync(email, subject, body);
    }

    public async Task SendPasswordResetLinkAsync(User user, string email, string resetLink)
    {
        const string subject = "Reset Your Password";
        var body = $"<h3>Password Reset Request</h3>" +
                   $"<p>We received a request to reset your password. You can do so by clicking <a href='{resetLink}'>this link</a>.</p>" +
                   $"<p>If you did not make this request, you can safely ignore this email.</p>";

        await SendEmailAsync(email, subject, body);
    }

    public async Task SendPasswordResetCodeAsync(User user, string email, string resetCode)
    {
        const string subject = "Your Password Reset Code";
        var body = $"<h3>Password Reset Request</h3>" +
                   $"<p>Your verification code to reset your password is: <b>{resetCode}</b></p>" +
                   $"<p>This code is valid for a limited time. Do not share it with anyone.</p>";

        await SendEmailAsync(email, subject, body);
    }

    private static async Task SendEmailAsync(string toEmail, string subject, string htmlMessage)
    {
        var host = Environment.GetEnvironmentVariable("SMTP_HOST") ?? "smtp.gmail.com";
        var portStr = Environment.GetEnvironmentVariable("SMTP_PORT");
        var port = int.TryParse(portStr, out var p) ? p : 587;
        var userEmail = Environment.GetEnvironmentVariable("SMTP_USER") ?? string.Empty;
        var password = Environment.GetEnvironmentVariable("SMTP_PASSWORD") ?? string.Empty;
        var senderName = Environment.GetEnvironmentVariable("SMTP_SENDER_NAME") ?? "Inventory App";
        
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(senderName, userEmail));
        emailMessage.To.Add(new MailboxAddress("", toEmail));
        emailMessage.Subject = subject;
        
        var bodyBuilder = new BodyBuilder {HtmlBody = htmlMessage};
        emailMessage.Body = bodyBuilder.ToMessageBody();
        
        using var client = new SmtpClient();
        
        await client.ConnectAsync(host, port, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(userEmail, password);
        await client.SendAsync(emailMessage);
    }
}