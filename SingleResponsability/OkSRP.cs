using System;

namespace SolidDemo.SingleResponsability
{
    internal class UserService
    {
        private readonly EmailService _emailService;
        public UserService()
        {
            _emailService = new EmailService();
        }

        public void Register(string email, string pwd)
        {
            if(!_emailService.ValidateEmail(email))
            {
                throw new Exception("Invalid email");
            }
            SRPDemoHelper.SaveUserToDb(email, pwd);
            _emailService.SendEmail(email, "Thank you for registering");
        }
    }

    internal class EmailService
    {
        public bool ValidateEmail(string email) => email.Contains("@");

        public void SendEmail(string to, string content) => SRPDemoHelper.SendEmail(to, content);
    }
}
