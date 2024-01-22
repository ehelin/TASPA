using System.Diagnostics;
using System.IO;
using System.Threading;

#pragma warning disable CS8601 // Possible null reference assignment.

namespace AiModelApi
{
	/// <summary>
	/// C# wrapper around python script in AiModelRunner Python project inside this solution.
	/// 
	/// NOTE: This is NOT meant to be a production system and is only for play AI model exploration w/Taspa chat app.
	/// </summary>
	public class PythonRunner
	{
		public static string PythonPath;
		public static string ScriptPath;

		private static bool exit = false;

		/// <summary>
		/// Message/response for interacting w/Python script.  Not ideal, but works for now.
		/// </summary>
		public static string message = string.Empty;
		public static string response = string.Empty;

		public static void BackgroundProcessThreadMethod()
		{
			using (Process process = new Process())
			{
				#region

				process.StartInfo.FileName = PythonPath;
				process.StartInfo.Arguments = ScriptPath;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardInput = true;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.CreateNoWindow = true;

				#endregion

				process.Start();

				using (StreamWriter sw = process.StandardInput)
				{
					using (StreamReader sr = process.StandardOutput)
					{
						while (!exit)
						{
							if (exit)
							{
								sw.WriteLine("exit");
							}
							if (!string.IsNullOrEmpty(message))
							{
								sw.WriteLine(message);

								// Receive and process the response
								message = string.Empty;
								response = sr.ReadLine();
							}
							Thread.Sleep(500);
						}
					}
				}

				process.WaitForExit();
			}
		}
	}
}