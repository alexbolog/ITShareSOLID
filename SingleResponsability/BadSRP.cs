namespace SolidDemo.SingleResponsability
{
    internal class BadUserService
    {
        public void Register(string email, string pwd)
        {
            if (!ValidateEmail(email))
            {
                throw new System.Exception("Invalid email");
            }
            SRPDemoHelper.SaveUserToDb(email, pwd);
            SendMail(email, "Thank you for registering");
        }

        public void SendMail(string to, string content)
        {
            SRPDemoHelper.SendEmail(to, content);
        }

        public bool ValidateEmail(string email) => email.Contains("@");
    }
}
