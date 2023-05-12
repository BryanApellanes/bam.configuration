using Bam.Net.CoreServices.ApplicationRegistration.Data;
using Bam.Net.ServiceProxy;
using System;

namespace Bam.Net.CoreServices
{
    public interface IUserRegistry
    {
        Func<string, string> GetConfirmationUrlFunction { get; set; }
        Func<string, string> GetPasswordResetUrlFunction { get; set; }
        int PasswordResetTokensExpireInThisManyMinutes { get; set; }
        string SmtpSettingsVaultPath { get; set; }

        event EventHandler ConfirmAccountFailed;
        event EventHandler ConfirmAccountSucceeded;
        event EventHandler ForgotPasswordFailed;
        event EventHandler ForgotPasswordSucceeded;
        event EventHandler LoginFailed;
        event EventHandler LoginSucceeded;
        event EventHandler RequestConfirmationEmailFailed;
        event EventHandler RequestConfirmationEmailSucceeded;
        event EventHandler ResetPasswordFailed;
        event EventHandler ResetPasswordSucceeded;
        event EventHandler SignOutFailed;
        event EventHandler SignOutStarted;
        event EventHandler SignOutSucceeded;
        event EventHandler SignUpFailed;
        event EventHandler SignUpSucceeded;

        object Clone();
        IServiceProxyResponse ConfirmAccount(string token);
        IServiceProxyResponse CreateEmail(string fromAddress = null, string fromDisplayName = null);
        IServiceProxyResponse ForgotPassword(string emailAddress);
        string GetCurrentUser();
        string[] GetRoles();
        string[] GetRoles(IUserResolver userResolver);
        dynamic GetSmtpSettingsVault(string applicationName = null);
        IUser GetUser(IHttpContext context);
        IServiceProxyResponse IsEmailInUse(string emailAddress);
        bool IsInRole(IUserResolver userResolver, string roleName);
        bool IsInRole(string roleName);
        IServiceProxyResponse IsUserNameAvailable(string userName);
        IServiceProxyResponse RequestConfirmationEmail(string emailAddress, int accountIndex = 0);
        IServiceProxyResponse ResetPassword(string passHash, string resetToken);
        IServiceProxyResponse SignOut();
        IServiceProxyResponse SignUp(string emailAddress, string userName, string passHash, bool sendConfirmationEmail);
    }
}