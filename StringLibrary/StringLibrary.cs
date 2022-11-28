using ClosedXML.Excel;
using System.Data;
using System.Text;

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
	public static void ExportOperationsToExcel(List<Operation> ops)
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
			dt.Rows.Add(emp.Index , emp.Description , emp.Date , emp.Result);
		}
		//using ClosedXML.Excel;
		using (XLWorkbook wb = new XLWorkbook())
		{
			wb.Worksheets.Add(dt);
			 
		    wb.SaveAs(@"C:\Users\kh.guesmi\Documents\documents\db\ReportOperations_"+ DateTime.Now.ToString("dd_MM_HH")+".xlsx");
		         
		}
	}


	public static void ExportUserInfoToExcel(List<User> ops)
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

			wb.SaveAs(@"C:\Users\kh.guesmi\Documents\documents\db\ReportUserInfo  _" + DateTime.Now.ToString("dd_MM_HH") + ".xlsx");

		}
	}

	public static void GetColumnValue<T>(object obj)
	{
		Console.WriteLine("this is"+obj.ToString());
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
		public User()
		{

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
