using Bookshare.ApplicationServices.EmailService.Models;

namespace Bookshare.ApplicationServices.EmailService.Constants
{
    public static class EmailTemplates
    {
        public static EmailTemplate Default { get; }
        public static EmailTemplate ResetPassword { get; }

        static EmailTemplates()
        {
            Default = new EmailTemplate
            {
                Body = "{0}",
                Layout = EmailLayouts.Default,
                Subject = "Default",
            };
            ResetPassword = new EmailTemplate
            {
                Body = "<a href='{0}'> Reset</a> - click to reset password",
                Layout = EmailLayouts.Default,
                Subject = "Study Sharp - ResetPassword",
            };
        }
    }
}
