using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using System.Net.Mail;
using System.Net;
using System.IO;

namespace CapaNegocio
{
    public class CN_Recursos
    {
        public static string GenerateKey()
        {
            string key = Guid.NewGuid().ToString("N").Substring(0,6);
            return key;
        }
        public static string ConvertToSHA256(string text)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (SHA256 sha256 = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = sha256.ComputeHash(enc.GetBytes(text));

                foreach (byte b in result)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }

        public static bool SendEmail (string email, string subject, string message)
        {
            bool result = false;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("montoyamontespi@gmail.com");
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient()
                {

                    Credentials = new NetworkCredential("montoyamontespi@gmail.com", "bykc kcbs rxef rdes"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                };
                smtp.Send(mail);
                result = true;
            } 
            catch (Exception e)
            {
                Console.WriteLine("error", e);
            }
            return result;
        }

        public static string GetImageBase64(string route, out bool conversion)
        {
            string textBase64 = string.Empty;
            conversion = true;

            try
            {
                byte[] bytes = File.ReadAllBytes(route);
                textBase64 = Convert.ToBase64String(bytes);
            }
            catch (Exception)
            {
                conversion = false;
            }
            return textBase64;
        }
    }
}
