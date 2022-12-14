using ClosedXML.Excel;
using System.Data;
using System.Text;
using System.Net;
using System.Net.Mail;
namespace UtilityLibraries;

public static class StringLibrary
{

	public static bool StartsWithUpper(this string? str)
	{
		if (string.IsNullOrWhiteSpace(str))
			return false;

		char ch = str[0];
		return char.IsUpper(ch);
	}

	/// <summary>
	///  Function demonstrates some of the FileStream constructors.
	/// </summary>
	/// <param name="fs"></param>
	/// <param name="value"></param>
	public static void AddText(FileStream fs, string value)
	{
		byte[] info = new UTF8Encoding(true).GetBytes(value);
		fs.Write(info, 0, info.Length);
	}

	/// <summary>
	/// The following example shows how to write to a file asynchronously. 
	/// The file path needs to be changed to a file that exists on the computer.
	/// </summary>
	/// <param name="fs"></param>
	/// <param name="value"></param>
	/// <param name="path"></param>
	public static async void CreateFileAsync(string value, string path)
	{
		UnicodeEncoding uniencoding = new UnicodeEncoding();
		byte[] result = uniencoding.GetBytes(value);
		string filename = path; // string filename = @"C:\Users\kh.guesmi\Documents\documents\db\MyTestAsync.txt";


		using (FileStream SourceStream = File.Open(filename, FileMode.OpenOrCreate))
		{
			SourceStream.Seek(0, SeekOrigin.End);
			await SourceStream.WriteAsync(result, 0, result.Length);
		}

	}

	/// <summary>
	/// Create an Excel file from list of data
	/// </summary>
	/// <param name="ops"></param>
	public static void ExportOperationsToExcel(List<Operation> ops, string path)
	{
		try
		{
			if (ops.Count > 0 && ops != null)
			{
				DataTable dt = new DataTable("Operations");
				dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Index"),
												new DataColumn("Description"),
												new DataColumn("Date"),
												new DataColumn("Result")
					});

				//fill datatable
				foreach (var emp in ops)
				{
					dt.Rows.Add(emp.Index, emp.Description, emp.Date, emp.Result);
				}
				//using ClosedXML.Excel;
				using (XLWorkbook wb = new XLWorkbook())
				{
					wb.Worksheets.Add(dt);

					if (!string.IsNullOrEmpty(path))
					{
						wb.SaveAs(path + DateTime.Now.ToString("dd_MM_HH_mmssfff") + ".xlsx");
					}
					else
					{
						wb.SaveAs(@"C:\Users\kh.guesmi\Documents\documents\db\ReportOperations_" + DateTime.Now.ToString("dd_MM_HH_mmssfff") + ".xlsx");
					}
				}
			}
		}
		catch (Exception ex)
		{

			string pathExp = @"C:\Users\kh.guesmi\Documents\documents\db\ExceptioReport_" + DateTime.Now.ToString("dd_MM_HH_mmssfff") + ".txt";

			// Delete the file if it exists.
			if (File.Exists(pathExp))
			{
				File.Delete(pathExp);
			}
			//Create the file.
			using (FileStream fs = File.Create(pathExp))
			{
				AddText(fs, "Today we have this exception "+ex.Message + " at " + DateTime.Now.ToString("dd_MM_HH_mmssfff") +".");
			}
		}
	}


	public static void ExportUserInfoToExcel(List<User> ops, string path)
	{
		try
		{
			DataTable dt = new DataTable("Operations");
			dt.Columns.AddRange(new DataColumn[2] { new DataColumn("MSISDN"),
												new DataColumn("NumWallet")
					});

			//fill datatable
			foreach (var emp in ops)
			{
				dt.Rows.Add(emp.Msisdn, emp.NumWallet);
			}
			//using ClosedXML.Excel;
			using (XLWorkbook wb = new XLWorkbook())
			{
				wb.Worksheets.Add(dt);
				if (!string.IsNullOrEmpty(path))
				{
					wb.SaveAs(path + DateTime.Now.ToString("dd_MM_HH_mmssfff") + ".xlsx");
				}
				else
				{
					wb.SaveAs(@"C:\Users\kh.guesmi\Documents\documents\db\ReportUserInfo_" + DateTime.Now.ToString("dd_MM_HH_mmssfff") + ".xlsx");
				}
			}
		}
		catch (Exception ex)
		{
			string pathExp = @"C:\Users\kh.guesmi\Documents\documents\db\ExceptioReport_" + DateTime.Now.ToString("dd_MM_HH_mmssfff") + ".txt";

			// Delete the file if it exists.
			if (File.Exists(pathExp))
			{
				File.Delete(pathExp);
			}
			//Create the file.
			using (FileStream fs = File.Create(pathExp))
			{
				AddText(fs, "Today we have this exception " + ex.Message + " at " + DateTime.Now.ToString("dd_MM_HH_mmssfff") + ".");
			}
		}
	}

	public static void GetColumnValue<T>(object obj)
	{
		Console.WriteLine("this is " + obj.ToString());
	}

	/// <summary>
	/// Send Email Notification with Gmail
	/// </summary>
	/// <param name="subject"></param>
	/// <param name="body"></param>
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
	public class User
	{
		public string Msisdn { get; set; }
		public string NumWallet { get; set; }
		public User(string msisdn, string numWallet)
		{
			Msisdn = msisdn;
			NumWallet = numWallet;
		}
		public User(){}
		public override string ToString()
		{
			return $" Phone number {Msisdn} , wallet number {NumWallet}";
		}
	}
	public class Operation
	{

		public Operation()
		{
			Index = "0";
			Description = "test";
			Date = DateTime.Now.ToString("dd-MM-HH:mm:ss:fff");
			Result = "-1";

			;
		}

		public Operation(string v1, string v2, string v3, string v4)
		{
			this.Index = v1;
			this.Description = v2;
			this.Date = v3;
			this.Result = v4;
		}

		public string Index { get; set; }
		public string Description { get; set; }
		public string Date { get; set; }
		public string Result { get; set; }
	}


}
