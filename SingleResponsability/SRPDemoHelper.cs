using System;
using System.Collections.Generic;
using System.Text;

namespace SolidDemo.SingleResponsability
{
    internal class SRPDemoHelper
    {
        public static void SaveUserToDb(string user, string pwd) => Console.WriteLine($"Saved {user} to db");

        internal static void SendEmail(string to, string content) => Console.WriteLine($"Email sent to {to} with content {content}");
    }
}
