using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
namespace Stt_ShowCase.Tools
{
	public class SendMail
	{
		public static void SendMailToSomeone(string subject, string body)
		{
			try
			{
				var fromAddress = new MailAddress("khaledguesmi666@gmail.com", "From Myself");
				var toAddress = new MailAddress("khaled.guesmi@esprit.tn", "To Myself");
				const string fromPassword = "mlnyghjnbwtbclxr";
				//const string fromPassword = "Khaled123120";


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
					smtp.Send(message);
				}
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}
		}
	}
}
