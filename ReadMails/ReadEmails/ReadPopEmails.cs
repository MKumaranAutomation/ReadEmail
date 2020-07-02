using System;
using MailKit.Net.Pop3;
using MailKit.Security;

namespace ReadEmails
{
	class ReadPopEmails
	{
		public static void Main(string[] args)
		{
			using (var client = new Pop3Client())
			{
				client.Connect("pop.gmail.com", 995, SecureSocketOptions.SslOnConnect);

				client.Authenticate("emailId", "Password");
				for (int i = 0; i < client.Count; i++)
				{
					var message = client.GetMessage(i);
					Console.WriteLine("Subject: {0}", message.Subject);
				}

				client.Disconnect(true);
			}
		}
	}
}