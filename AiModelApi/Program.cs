using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace AiModelApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// Start python script
			PythonRunner.PythonPath = "C:\\Users\\erich\\AppData\\Local\\Programs\\Python\\Python310\\python.exe";
			PythonRunner.ScriptPath = "C:\\EricDocuments\\Personal\\Taspa2\\AiModelRunner\\chat.py";
			Thread backgroundThread = new Thread(PythonRunner.BackgroundProcessThreadMethod);
			backgroundThread.Start();

			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllers();

			var app = builder.Build();
			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}