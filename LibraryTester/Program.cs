using UtilityLibraries;
using static UtilityLibraries.StringLibrary;

class Program
{
	static void Main(string[] args)
	{

		#region EXPORT USER MSISDN TO EXCEL
		//list to export
		List<User> user_ops = new List<User>();
		//create test values
		User user1 = new User("54120892", "1234567891235698");
		User user2 = new User("27950782", "1234567891235698");
		User user3 = new User("54777321", "1234567891235698");
		User user4 = new User("94777321", "1234567891235698");
		//add to list
		user_ops.Add(user1);
		user_ops.Add(user2);
		user_ops.Add(user3);
		user_ops.Add(user4);
		ExportUserInfoToExcel(user_ops);

		GetColumnValue<User>(user1);

		#endregion

		#region Create EXCEL Operation

		List<Operation> ops = new List<Operation>();
		Operation op1 = new Operation("1", "Test1", DateTime.Now.ToString("dd-MM-HH:mm:ss:fff"), "1");
		Operation op2 = new Operation("2", "Test2", DateTime.Now.ToString("dd-MM-HH:mm:ss:fff"), "1");
		Operation op3 = new Operation("3", "Test3", DateTime.Now.ToString("dd-MM-HH:mm:ss:fff"), "1");
		Operation op4 = new Operation("4", "Test4", DateTime.Now.ToString("dd-MM-HH:mm:ss:fff"), "1");
		ops.Add(op1);
		ops.Add(op2);
		ops.Add(op3);
		ops.Add(op4);
		ExportOperationsToExcel(ops);
		#endregion

		#region FileStream
		string path = @"C:\Users\kh.guesmi\Documents\documents\db\MyTest.txt";

		// Delete the file if it exists.
		if (File.Exists(path))
		{
			File.Delete(path);
		}
		//Create the file.
		using (FileStream fs = File.Create(path))
		{
			StringLibrary.AddText(fs, "This is some text");
			StringLibrary.AddText(fs, "This is some more text,");
			StringLibrary.AddText(fs, "\r\nand this is on a new line");
			StringLibrary.AddText(fs, "\r\n\r\nThe following is a subset of characters:\r\n");

			for (int i = 1; i < 120; i++)
			{
				StringLibrary.AddText(fs, Convert.ToChar(i).ToString());
			}
		}

		string path1 = @"C:\Users\kh.guesmi\Documents\documents\db\MyTestAsync.txt";
		//Create file Async
		StringLibrary.CreateFileAsync("This is my async Methode to create file ", path1);



		#endregion

		#region String Library
		int row = 0;
		do
		{
			if (row == 0 || row >= 25)
				ResetConsole();

			string? input = Console.ReadLine();

			if (string.IsNullOrEmpty(input)) break;
			Console.WriteLine($"Input: {input}");
			Console.WriteLine("Begins with uppercase? " +
				 $"{(input.StartsWithUpper() ? "Yes" : "No")}");
			Console.WriteLine();
			row += 4;
		} while (true);
		return;
		// Declare a ResetConsole local method
		void ResetConsole()
		{
			if (row > 0)
			{
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
			}
			Console.Clear();
			Console.WriteLine($"{Environment.NewLine}Press <Enter> only to exit; otherwise, enter a string and press <Enter>:{Environment.NewLine}");
			row = 3;
		}
		#endregion

	}


}