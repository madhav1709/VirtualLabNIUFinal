using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace VirtualLab.Areas.Identity.Pages.Assignments.Experiments
{
    public class SolarCellSeriesModel : PageModel
    {
		[BindProperty]
		public InputModel Input { get; set; }

		public class InputModel
		{
			[Required]
			[Display(Name = "Irradiation (Wb/m)")]
			public int Suns { get; set; }

			[Required]
			[Display(Name = "Temperature (°C)")]
			public int TaC { get; set; }

			[Required]
			[Display(Name = "Resistance (Ω)")]
			public int Ra { get; set; }

			public double Va = 0.0001;

			public int Ns = 3;

			public int Np = 1;
		}

        public string finalResult = null;

        public void OnGet()
		{
		}

		public void OnPost()
		{
			string JSONresult = JsonConvert.SerializeObject(Input);


			const int portNumber = 6811;
			const string hostName = "127.0.0.1";

			try
			{
				TcpClient client = new TcpClient(hostName, portNumber);

				// Translate the passed message into ASCII and store it as a Byte array.
				Byte[] data = System.Text.Encoding.ASCII.GetBytes(JSONresult.ToString());

				// Get a client stream for reading and writing.
				NetworkStream stream = client.GetStream();

				// Send the message to the connected TcpServer. 
				stream.Write(data, 0, data.Length);

				Thread.Sleep(5000);

				// Check to see if this NetworkStream is readable.
				if (stream.CanRead)
				{
					byte[] myReadBuffer = new byte[1024];
					StringBuilder myCompleteMessage = new StringBuilder();
					int numberOfBytesRead = 0;

					// Incoming message may be larger than the buffer size.
					do
					{
						numberOfBytesRead = stream.Read(myReadBuffer, 0, myReadBuffer.Length);

						myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));

					}
					while (stream.DataAvailable);

					// Print out the received message to the console.
					Console.WriteLine("You received the following message : " +
												 myCompleteMessage);

                    finalResult = myCompleteMessage.ToString();
                }
				else
				{
					Console.WriteLine("Sorry.  You cannot read from this NetworkStream.");
				}

				// Close everything.
				stream.Close();
				client.Close();
			}
			catch (ArgumentNullException e)
			{
				Console.WriteLine("ArgumentNullException: {0}", e);
			}
			catch (SocketException e)
			{
				Console.WriteLine("SocketException: {0}", e);
			}

		}
	}
}